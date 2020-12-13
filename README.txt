IRF BEADANDÓ

Kapott tételek: CBAB

Adatok importálása: C) XML feldolgozás (fájlból, vagy webszolgáltatásból)
Adatfeldolgozás: B) Kifejtett setter ág használata, értékadásra értelemszerű funkciók hívása
Adatok exportálása/megjelenítése: A) Írás CSV fájlba
Általános elemek: B) Enumeráció létrehozása és használata

ÖTLET:

Mivel XML feldolgozást és CSV-be írást kell kidolgoznom a programomban, így a munkámból inspirálódtam az ötletelés során.
SAP master data management-tel is foglalkozom, és sokszor kell adatokat betölteni SAP-ba, melyeket adott esetben egy külső feeder küld.
A programom alapkoncepciója tehát az, hogy egy külső interface által küldött XML fájlt olvastatok be, majd az adatok helyességének ellenőrzése után CSV-be íratom.
Számos esetben a feederek az SAP struktúrának nem megfelelő adatokat küldenek, nem az SAP névkonvencióját használják, tehát sokszor tartalmaznak tipikus hibákat.
A programom megoldást nyújt arra, hogy SAP-ba betöltés előtt le tudjuk könnyen ellenőrizni és átkonvertálni CSV-be az adott fájlt.

Az XML fájl CostCenter master data-kat fog tartalmazni az alábbi attribútumokkal:

CTR = String (6 karakteres) - a Cost Center azonosítója
VFROM = Date (YYYY/MM/DD) - a Cost Center érvényességének a kezdete
VTO = Date (YYYY/MM/DD) - a Cost Center érvényességének a vége
TYPE = String - a Cost Center típusa, 2 értéke lehet: Headcount(HC) és Nonheadcount(NH)
PROFCTR = String (PXXXX) - a Profit Center azonosítója, P-vel kezdődik és 4 számjegyre végződik
ORGCODE = String (1 karakteres) - megadja, hogy melyik Organization-be tartozik, csak a HC Cost Centereknél lehet kitöltve
GEOCODE = String (2 karakteres) - megadja, hogy melyik Földrajzi területhez (országhoz) tartozik, csak a NH Cost Centereknél lehet kitöltve

Enumeráció használata: Az ORGCODE-ok lehetséges értékeit enumerációban tárolom. (1=FI, 2=BI, 3=MA)

A beolvasott adatokat egy DataGridView-ban jelenítem meg.

A változtatások után kiíratom CSV-be az adatokat az XML sémájára: CTR, VFROM, VDO, TYPE, PROFCTR, ORGCODE, GEOCODE.

Programtervezési minta használata: 
Építő programtervezési mintát alkalmazok a projektemben, ennek bővebb leírása a PATTERN.txt fájlban található.


