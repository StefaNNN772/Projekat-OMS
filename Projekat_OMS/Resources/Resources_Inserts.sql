insert into ElektricniTip (nazivet) values ('Tranzistor');
insert into ElektricniTip (nazivet) values ('Otpornik');
insert into ElektricniTip (nazivet) values ('Kondenzator');
commit;

insert into ElektricniElement (nazivee, tipee, x, y) values ('Mrezni element', 1000, 100, 200);
insert into ElektricniElement (nazivee, tipee, x, y, naponskinivoee) values ('Trafo stanica', 1001, 115, 105, 'Visok napon');
insert into ElektricniElement (nazivee, tipee, x, y, naponskinivoee) values ('Mrezna stanica', 1002, 10, 20, 'Srednji napon');
commit;