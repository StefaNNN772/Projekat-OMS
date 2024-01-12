# Projekat-OMS
Projekat za ERS
            OMS – evidencija kvarova u električnoj mreži
Outage Management System (OMS), podrazumeva rukovanje greškama i planiranim operacijama u
distributivnoj mreži. OMS je zadužen za nadgledanje operacija/promena u distributivnoj mreži, koje
mogu da dovedu do prekida napajanja. Uzroci, odnosno same operacije, mogu biti planirani (kao u
slučaju redovnog održavanja) ili neplanirani (kao rezultat greške). OMS ima zadatak da vodi
evidenciju svih prekida, planiranih ili neplaniranih, unutar jedne distributivne mreže.
Klijent je kompanija za distribuciju električne energije. Aplikacija treba da se bavi evidencijom
planiranih operacija.

Slede korinsnički zahtevi.
1. Unos podataka o kvaru
Unos kvara se vrši kroz korisnički interfejs. Unosom kvara automatski se kreiraju i upisuju u bazu
podataka:
- ID kvara - tekstualno obeležje koje se ne može menjati. ID kvara se sastoji od datuma i
vremena kvara i rednog broja kvara u tom danu, u obliku “yyyyMMddhhmmss_rb”, gde je
“yyyyMMddhhmmss” format datuma i vremena, a “rb” je redni broj kvara u tom danu.
- Vreme kreiranja kvara – datumsko obeležje koje se ne može menjati.
- Status – ima podrazumevanu vrednost “Nepotvrđen”, a može da ima vrednosti “U popravci”,
“Testiranje”, i “Zatvoreno”.

Podaci koji se popunjavanju za kvar su i:
- Kratak opis kvara
- Električni element na kome se desio kvar
- Opis kvara – tekstualni opis problema koji se desio
- Izvršene akcije. Za svaki kvar se može izvršiti više akcija. Svaka akcija sadrži vreme akcije i
opis urađenog posla

Evidencije električnih elemenata
- Kroz korisnički interfejs vrši se evidencija električnih elemenata u mreži
- Svaki električni elemenat sadrži ID elementa, naziv elementa, tip elementa i geografsku
lokaciju sa koordinatama. Tipovi elemenata se evidentiraju u tekstualne fajlove, ali ne mora
da postoji korisnički interfejs za njihovu evidenciju
- Naponski nivo – ima podrazumevanu vrednost “srednji napon ”, a mogude vrednosti su i
“visoki napon” i “nizak napon”

2. Lista kvarova
U korisničkom interfejsu treba da postoji mogudnost prikaza liste kvarova koji su kreirani u
određenom vremenskom opsegu, sa datumom kvara, kratkim opisom kvara i statusom.
Granični datumi se unose preko korisničkog interfejsa. Takođe treba da postoji mogudnost
izbora pojedinačnog kvara sa prikazom podataka o izabranom kvaru. Podatke otvorenog
kvara mogude je aužurirati, osim u slučaju da je status kvara “zatvoreno”.

Prilikom izbora pojedinačnog kvara za prikaz, ukoliko je status kvara “U popravci”, potrebno
je definisati njegov prioritet. Za svaki dan koji je prošao od prvog registrovanja kvara,
prioritet se povedava za 1. Za svaku izvršenu akciju na izabranom kvaru prioritet se povedava
za 0.5. Što je broj vedi to je vedi prioritet popravke izabranog kvara.

3. Kreiranje dokumenta
Za svaki kvar treba da postoji mogudnost kreiranja Excel dokumenta koji de sadržati sledede
kolone:
- ID kvara
- Naziv elementa na kome se desio kvar
- Naponski nivo
- Spisak izvršenih akcija
U okviru ove funkcionalnosti očekivano je da postoji mogudnost korišdenja drugih formata (npr.
PDF, CSV …).
Tehnički i implementacioni zahtevi
1. Aplikacija treba da da bude razvijena poštujudi Agile/Scrum metodologiju razvoja, uz
upotrebu AzureDevOps platforme.
2. Baza podataka može da bude implementirana kroz neki SUBP (MS SQL Server, Oracle), kroz
neki od embeded sistema za baze podataka (SQLite, MS Access) ili kroz XML.
3. U okviru projekta potrebno je primeniti SOLID principe i načela čiste arhitekture
4. Aplikacija treba da bude pokrivena Unit testovima
