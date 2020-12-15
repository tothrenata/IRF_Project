IRF BEADANDÓ

Kapott tételek: CBAB

Adatok importálása: C) XML feldolgozás (fájlból, vagy webszolgáltatásból)
Adatfeldolgozás: B) Kifejtett setter ág használata, értékadásra értelemszerű funkciók hívása
Adatok exportálása/megjelenítése: A) Írás CSV fájlba
Általános elemek: B) Enumeráció létrehozása és használata

ÖTLET:

Mivel XML feldolgozást és CSV-be írást kell kidolgoznom a programomban, így a munkámból inspirálódtam az ötletelés során. SAP Master Data Management-tel foglalkozom, mely során sokszor kell adatokat betölteni SAP-ba. Ezeket adott esetben egy külső feeder is küldheti, mely egy külsős rendszerből gyűjti össze az adatokat. A programom alapkoncepciója tehát az, hogy egy külső interface által küldött XML fájlt olvastatok be, majd az adatok helyességének ellenőrzése után CSV-be íratom. Számos esetben a feederek az SAP struktúrának nem megfelelő adatokat küldenek, nem az SAP névkonvencióját használják, tehát sokszor tartalmaznak tipikus hibákat. A programom megoldást nyújt arra, hogy SAP-ba betöltés előtt le tudjuk könnyen ellenőrizni és elmenteni CSV-be az adott fájlt.

Az XML fájl CostCenter master data-kat tartalmaz az alábbi attribútumokkal:

CTR = String (6 karakteres) - a Cost Center egyedi azonosítója
VFROM = Date (YYYY/MM/DD) - a Cost Center érvényességének a kezdete
VTO = Date (YYYY/MM/DD) - a Cost Center érvényességének a vége, alapértelmezetten végtelennek kell lennie (9999/12/31), mivel csak ekkor lehet használatban az adott Cost Center
TYPE = String - a Cost Center típusa, 2 értéke lehet: Headcount(HC) vagy Nonheadcount(NH)
PROFCTR = String (5 karakteres) - a Profit Center azonosítója (egy Profit Centerhez több Cost Center is tartozhat)
ORGCODE = Megadja, hogy melyik Organization-be tartozik, csak a HC Cost Centereknél lehet kitöltve
GEOCODE = String (2 karakteres) - megadja, hogy melyik Földrajzi területhez (pl. országhoz) tartozik, csak a NH Cost Centereknél lehet kitöltve

Enumeráció használata: Az ORGCODE-ok csak 3 specifikus értéket vehetnek fel, a lehetséges értékeket az OrgCodes enumerációban tárolom (1=FI, 2=BI, 3=MA).

Kifejtett setter ág: Az enumeráció miatt az ORCODE-on típuskonverziót kell végrehajtani, mivel CSV-be a kétjegyű String kerül kiírásra.

User Interface:

A beolvasott adatokat egy ReadOnly tulajdonságú DataGridView-ban jelenítem meg. Itt tehát manuálisan nem lehet átírni az adatokat.
A 'Check correction' gombra kattintva hibákat tartalmazó sorokat egy másik DataGridView-ban jelenítem meg, ahol a hibás mezőket ki lehet javítani.
A javítás után az 'Apply correction' gombra kattintva frissül a Cost Center Master Data listánk a javításokkal.
A 'Save as CSV' gombra kattintva elmenthetjük az Cost Centerek adatait az XML sémájára: CTR, VFROM, VDO, TYPE, PROFCTR, ORGCODE, GEOCODE. Itt kiválaszthatjuk a mentés helyét és megadhatjuk a fájl nevét is.

Programtervezési minta használata:
Építő programtervezési mintát alkalmazok a projektemben, ennek bővebb leírása a PATTERN.txt fájlban található.