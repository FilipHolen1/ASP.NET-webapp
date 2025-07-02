# Aplikacija za Upravljanje Studentima i Profesorima

Aplikacija omogućuje pregled, dodavanje, uređivanje i brisanje studenata i profesora.  
Svaki student ima podatke poput imena, prezimena, emaila, datuma rođenja i godine razreda.  
Moguće je pogledati ocjene od svakog studenta.  
Profesori imaju podatke imena, prezimena, emaila i listu predmeta koje predaju.  
Prilikom kreiranja ili uređivanja profesora moguće je označiti predmete koje profesor predaje.

---

## ✅ Smislenost objektnog modela – 11 bodova
- ✔ Da li objekti imaju smisla (minimalno 4 entity framework klase, ne računajući User)
- ✔ Da li tipovi podataka u objektima imaju smisla (datumi, nullable gdje treba, int vs string)
- ✔ Da li su naznačene ispravne veze među objektima (1-N, N-N, nasljeđivanje)

---

## 🌐 MVC Routing i URL prostori – 3 boda
- ✔ Da li postoji kompletni izbornik u aplikaciji?
- X Postoji li custom ruta definirana u RouteConfig-u? (recimo, /kompanije/pregled i sl.)
- ✔ Da li postoji ruta definirana atributima/anotacijama?

---

## 🛠️ CRUD operacije i osnovni koncepti rukovanja entitetima – 24 boda
- ✔ Da li je kroz aplikaciju moguće izmijeniti podatke za barem 2 entiteta (ovisno o poslovnim pravilima)
- ✔ Postoji li zajednički partial view na edit + create formi?
- ✔ Postoji li forma za pretraživanje koja koristi AJAX za dohvat rezultata?
- ✔ Postoji li validacija (server side)
- ✔ Postoji li validacija (client side)
- ✔ Drop down liste (unos vezanih vrijednosti obvezno preko drop down liste)
- ✔ Postoji li seed za unos nekih inicijalnih vrijednosti (primjerice, gradovi i slično)
- ✔ Jesu li ispravno implementirane migracijske skripte (postoji li initial i bar još jedna migracija)
- ✔ Postoje li barem 3 elementa na sučelju implementirani pomoću Tag Helper-a?
- X Postoji li datumska kontrola i funkcionira li na barem 2 jezika s različitim formatom datuma?
- ✔ Je li korisničko sučelje napravljeno slijeđenjem osnovnih bootstrap principa?
- ✔ Postoji li "delete" implementiran pomoću AJAX poziva?

---

## 🏗️ Organizacija aplikacije – 7 bodova
- ✔ Postoji li DAL i model sloj?
- ✔ Jesu li ispravni elementi u svakom sloju?

---

## 🔐 Autorizacija i autentikacija – 8 bodova
- X Da li je implementiran OWIN model?
- X Postoje li odvojene role za neke dijelove aplikacije?
- X Da li je OWIN model ukombiniran sa vlastitom bazom?
- X Da li je moguće registrirati korisnika (obično + jedan od servisa kao što je Google ili FB)?

---

## 🔁 Web API – 7 bodova
- X Postoji li mogućnost dohvata barem jednog tipa entiteta putem API-ja? (lista, preko ID-a)
- X Postoji li mogućnost dodavanja, izmjene i brisanja barem jednog entiteta putem API-ja?
- X Xamarin aplikacija za prikaz jednog tipa podatka (opcionalno)

---

## ☁️ Deployment i automatizacija – 15 bodova (dodatno)
- X Deployment na lokalni IIS server
- X OpenAI integracija (chat-like pretraga ili slično)
