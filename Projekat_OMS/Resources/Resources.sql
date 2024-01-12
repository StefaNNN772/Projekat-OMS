--skripte za elektricni tip
CREATE SEQUENCE ele_tip_sekvenca
    START WITH 1000
    INCREMENT BY 1
    NOMAXVALUE
    NOCYCLE;

create table ElektricniTip (
    idet integer default ele_tip_sekvenca.NEXTVAL,
    nazivet varchar2(50) not null
);

alter table ElektricniTip add(
    constraint et_pk primary key (idet),
    constraint et_uq unique (nazivet)
);

--skripte za elektricni element
CREATE SEQUENCE ele_element_sekvenca
    START WITH 200
    INCREMENT BY 1
    NOMAXVALUE
    NOCYCLE;

create table ElektricniElement (
    idee integer default ele_element_sekvenca.NEXTVAL,
    nazivee varchar2(30) not null,
    tipee integer not null,
    x integer not null,
    y integer not null,
    naponskinivoee varchar(50) default 'Srednji napon'
);

alter table ElektricniElement add (
    constraint ee_pk primary key (idee),
    constraint ee_ch check (naponskinivoee in ('Srednji napon', 'Nizak napon', 'Visok napon')),
    constraint ee_fk foreign key (tipee) references ElektricniTip (idet),
    constraint ee_uq unique (nazivee)
);

--skripte za kvar
create table Kvar (
    idk varchar2(32) not null,
    vrijemekreiranja varchar2(10) default TO_CHAR(SYSDATE, 'yyyy-MM-dd') not null,
    statusk varchar2(30) default 'Nepotvrdjen',
    kratakopis varchar(250) not null,
    ele_element integer not null,
    opisproblema varchar(250) not null
);

CREATE SEQUENCE kvar_sekvenca
    START WITH 1
    INCREMENT BY 1
    NOMAXVALUE
    NOCYCLE
    CACHE 20;
CREATE OR REPLACE TRIGGER kvartrigger
BEFORE INSERT ON Kvar
FOR EACH ROW
BEGIN
    :NEW.idk := TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS') || '_' || TO_CHAR(kvar_sekvenca.NEXTVAL, 'FM0000');
END;
/

CREATE OR REPLACE TRIGGER datum_kvar_trigger
BEFORE INSERT ON kvar
FOR EACH ROW
BEGIN
    :NEW.vrijemekreiranja := TO_CHAR(SYSDATE, 'YYYYMMDDH');
END;
/

alter table Kvar add(
    constraint kv_pk primary key (idk),
    constraint kv_st check (statusk in ('Nepotvrdjen', 'U popravci', 'Testiranje', 'Zatvoreno')),
    constraint kv_fk foreign key (ele_element) references ElektricniElement(idee)
);

--skripte za akcije
CREATE SEQUENCE akcija_sekvenca
    START WITH 100
    INCREMENT BY 1
    NOMAXVALUE
    NOCYCLE;

create table Akcija (
    ida integer default akcija_sekvenca.NEXTVAL,
    idk varchar2(32) not null,
    datumakcije varchar2(20),
    opisa varchar2(250) not null
);

alter table Akcija add(
    constraint ak_pk primary key (ida),
    constraint ak_fk foreign key (idk) references Kvar(idk)
);

CREATE OR REPLACE TRIGGER datum_akcija_trigger
BEFORE INSERT ON akcija
FOR EACH ROW
BEGIN
    :NEW.datumakcije := TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS');
END;
/