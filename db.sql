drop database if exists as3;
create database as3;
use as3;


-- structura
create table patients(
	id int(6) primary key auto_increment not null, -- identity card number
	name varchar(45),
	cnp char(13) unique,
	birthdate date,
	address varchar(2048)
);


-- useri
create table us(
	id int(6) primary key not null auto_increment,
	name varchar(45) unique,
	parola varchar(45),
	tip int(4)	-- 0 admin 1 doctor 2 secretara
);


-- useri
create table tk(
	token char(90) unique,
	usid int(6),
	tip int(4) -- tipul userului
);


create table consultations(
	id int(6) primary key auto_increment not null,
	patientid int(6),
	doctorid int(6),
	starttime datetime,
	endtime datetime,
	description varchar(2048),
	foreign key (doctorid) references us(id),
	foreign key (patientid) references patients(id)
);


-- inserari
insert into patients(name, cnp, birthdate,address) values
("Ionn","1234567890123","2018/01/02","Strada Unirii, nr 9"),
("Ana","2234567890123","2018/01/03","Strada Unirii, nr 10"),
("Bogdan","1334567890123","2018/01/04","Strada Unirii, nr 11")
;


insert into us(name,parola,tip) values
("Mircea","1234",1),
("Andreea","1234",1),
("Ion","1234",2),
("Maria","1234",0),
("a","1234",0), -- admin
("d","1234",1), -- doctor
("s","1234",2) -- secretara
;


insert into `consultations`(patientid,doctorid,starttime,endtime,description) values
(1,2,"2017/05/06 14:00:00","2017/05/05 15:00:00","Description"),
(2,2,"2017/05/06 14:00:00","2017/05/06 15:00:00","Description"),
(3,1,"2017/05/06 14:00:00","2017/05/06 15:00:00","Description")
;




-- 
-- Proceduri
-- 


-- update patient
drop procedure if exists updatePatient;
delimiter //
create procedure updatePatient(`_name` varchar(45),
							_cnp varchar(13),
							_birthdate varchar(45),
							_address varchar(2048))
begin
	update `patients`
	set `patients`.name = _name,
		`patients`.birthdate = _birthdate,
		`patients`.address = _address
	where `patients`.cnp = _cnp;
end //
delimiter ;




-- add patient
drop procedure if exists addPatient;
delimiter //
create procedure addPatient(`_name` varchar(45),
							_cnp varchar(13),
							_birthdate varchar(45),
							_address varchar(2048))

begin
	set @iid = null;
	
	select id into @iid
	from patients
	where cnp = _cnp;
	
	if @iid is null then
		insert into patients(`name`,cnp,birthdate,address) values (_name,_cnp,_birthdate,_address);
	end if;
end //
delimiter ;



-- add or update user
drop procedure if exists updateUser;
delimiter //
create procedure updateUser(`_name` varchar(45),
							_parola varchar(45),
							_tip int(4))

begin
	set @e = null;

	select id into @e
	from us
	where us.name = _name;
	
	if @e is null then	-- adauga o noua intrare daca userul nu exista
		INSERT INTO us(name, parola, tip) VALUES(_name, _parola, _tip);
	else	-- suprascrie vechea inregistrare
		update `us`
        set `us`.parola = _parola,
			`us`.tip = _tip
        where id = @e;
	end if;
end //
delimiter ;



-- sterge user
drop procedure if exists deluser;
delimiter //
create procedure deluser(_name varchar(256))
begin
	delete
	from us
	where us.name = _name;
end //
delimiter ;






-- adauga consultatie
drop procedure if exists  addConsultation;
delimiter //
create procedure addConsultation( _descriere varchar(2048),  _numeDoc varchar(45),  _cnp char(13),  _start datetime,  _end datetime)
begin 
	select id into @idp
	from patients
	where patients.cnp = _cnp;
	

	select id into @idd
	from us
	where us.`name` = _numeDoc;
	
	
	if    _numeDoc is not null    and   _cnp is not null     and   _start is not null     and _end is not null    then
		insert into consultations(patientid,doctorid,starttime,endtime,description)
		values (@idp,@idd,_start,_end,_descriere);
	end if;

	
end //
delimiter ;






-- sterge consultatiile de dupa data curenta
drop procedure if exists  deleteConsultation;
delimiter //
create procedure deleteConsultation(_cnp char(13))
begin 
	select id into @idp
	from patients
	where patients.cnp = _cnp;

	DELETE FROM consultations 
	WHERE consultations.patientid=@idp and consultations.starttime>NOW();
end //
delimiter ;



-- update ultima consultatie
drop procedure if exists  updateConsultation;
delimiter //
create procedure updateConsultation( _descriere varchar(2048),  _numeDoc varchar(45),  _cnp char(13),  _start datetime,  _end datetime)
begin 
	select id into @idp -- id pacient
	from patients
	where patients.cnp = _cnp;
	
	select id into @idd -- id doctor
	from us
	where us.`name` = _numeDoc;

	update consultations
	set consultations.description = _descriere, consultations.starttime=_start, consultations.endtime=_end, consultations.doctorid=@idd
	where consultations.id=@idp
	order by consultations.id desc 
	limit 1;
		
	-- insert into consultations(patientid,doctorid,starttime,endtime,description)
	-- values (@idp,@idd,_start,_end,_descriere);
end //
delimiter ;



-- doctorul adauga detalii la ultima consultatie a pacientului de cnp dat
drop procedure if exists  adc;
delimiter //
create procedure adc( _descriere varchar(2048),  _cnp char(13)) -- add consultation details
begin 
	select id into @idp -- id pacient
	from patients
	where patients.cnp = _cnp;
	
	update consultations
	set consultations.description = concat(consultations.description,_descriere)
	where consultations.id=@idp
	order by consultations.id desc 
	limit 1;
end //
delimiter ;



-- doctorul suprascire a pacientului de cnp dat
drop procedure if exists  udc;
delimiter //
create procedure udc( _descriere varchar(2048),  _cnp char(13)) -- update consultation details
begin 
	select id into @idp -- id pacient
	from patients
	where patients.cnp = _cnp;
	
	update consultations
	set consultations.description = _descriere
	where consultations.id=@idp
	order by consultations.id desc 
	limit 1;
end //
delimiter ;


-- adauga token
drop procedure if exists addToken;
delimiter //
create procedure addToken( _token char(90),  _username varchar(45)) -- update consultation details
begin 
	select id into @usid
	from us
	where us.name = _username;
	
	select tip into @tip
	from us
	where us.id = @usid;

	insert into tk(token,usid,tip) values (_token, @usid,@tip);
end //
delimiter ;
