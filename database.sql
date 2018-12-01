CREATE TABLE Doctors (
ID int Primary key identity (1,1) not null,
FirstName varchar(50) not null,
Surname varchar(50) not null,
PWZNumber varchar(7) unique not null )



CREATE TABLE Patients (
ID int Primary key identity (1,1) not null,
DoctorID int foreign key references Doctors(ID) not null,
FirstName varchar(50) not null,
SecondName varchar(50) null,
Surname varchar(50) not null,
PESEL varchar(11) unique not null,
[Address] varchar (250) not null )



CREATE TABLE VisitTypes (
ID int Primary key identity (1,1) not null,
[Name] varchar (100) )



CREATE TABLE Visits (
ID int Primary key identity (1,1) not null,
TypeID int foreign key references VisitTypes(ID) not null,
VisitDate DateTime not null,
[Description] varchar (max) null )




CREATE Table Treatments (
ID int Primary key identity (1,1) not null,
[Type] varchar (50) not null,
[Description] varchar (max) null )



CREATE Table Diseases (
ID int Primary key identity (1,1) not null,
PatientID int foreign key references Patients(ID) not null,
TreatmentID int foreign key references Treatments(ID) not null,
[Description] varchar (max) null )




INSERT INTO Treatments(Type, Description)
Values ('Rehabilitacja', 'Kompleksowe i zespołowe działanie, które ma na celu przywrócenie pacjentowi pełnej lub maksymalnej do osiągnięcia sprawności fizycznej')
INSERT INTO Treatments(Type, Description)
Values ('Farmakoterapia', 'Leczenie pacjenta przy użyciu leków')
INSERT INTO Treatments(Type, Description)
Values ('Chemioterapia', 'Używanie syntetycznych związków chemicznych w celu zwalczania chorób nowotworowych')
INSERT INTO Treatments(Type, Description)
Values ('Psychoterapia', 'Stosowanie metod psychologicznych w celu poprawy dobrostanu i zdrowia psychicznego')



INSERT INTO Patients(DoctorID, FirstName, SecondName, Surname, PESEL, [Address])
Values (3, 'Karol', 'Gniewomir', 'Stachowicz', '27111113348', 'ul. Kórnicka 36/11 87-213 Poznań')
INSERT INTO Patients(DoctorID, FirstName, SecondName, Surname, PESEL, [Address])
Values (4, 'Piotr', 'Mateusz', 'Frontczak', '57091170697', 'ul. Długa 1 m. 10 23-573 Brzezie')
INSERT INTO Patients(DoctorID, FirstName, SecondName, Surname, PESEL, [Address])
Values (4, 'Michał', 'Kamil', 'Semeniuk', '61112890402', 'ul. Sikorskiego 12/44 11-323 Śrem')
INSERT INTO Patients(DoctorID, FirstName, SecondName, Surname, PESEL, [Address])
Values (3, 'Adam', 'Hubert', 'Wojewódzki', '00322589281', 'ul. Umultowska 3 m. 33 87-876 Poznań')
INSERT INTO Patients(DoctorID, FirstName, SecondName, Surname, PESEL, [Address])
Values (3, 'Artur', 'Marcin', 'Dutka', '22062483582', 'ul. Helsztyńskiego 11/11 23-321 Gostyń')



INSERT INTO Visits (PatientID, TypeID, VisitDate, [Description])
Values (1, 3, Convert(datetime2,'2018-11-30 15:30:00', 120), 'Pacjent nie zgłosił żadnych dolegliwości')
INSERT INTO Visits (PatientID, TypeID, VisitDate, [Description])
Values (2, 1, Convert(datetime2,'2018-05-24 12:00:00', 120), 'Nie wykryto żadnych niepokojących objawów')
INSERT INTO Visits (PatientID, TypeID, VisitDate, [Description])
Values (3, 2, Convert(datetime2,'2018-12-24 09:30:00', 120), 'Pacjentowi przypisano leki')
INSERT INTO Visits (PatientID, TypeID, VisitDate, [Description])
Values (4, 4, Convert(datetime2,'2018-01-01 13:15:00', 120), 'Wykryto niepokojące objawy, pacjent skierowany do specjalisty')
INSERT INTO Visits (PatientID, TypeID, VisitDate, [Description])
Values (5, 1, Convert(datetime2,'2018-11-01 17:45:00', 120), 'Prawidłowo przeprowadzony')



INSERT INTO Diseases(PatientID, TreatmentID, [Description])
Values (1, 3, 'Nowotwór trzustki')
INSERT INTO Diseases(PatientID, TreatmentID, [Description])
Values (2, 1, 'Przepuklina kręgosłupa')
INSERT INTO Diseases(PatientID, TreatmentID, [Description])
Values (3, 2, 'Angina')
INSERT INTO Diseases(PatientID, TreatmentID, [Description])
Values (4, 4, 'Zaburzenia lękowe')
INSERT INTO Diseases(PatientID, TreatmentID, [Description])
Values (5, 1, 'Problemy z mobilnością stawu biodrowego')