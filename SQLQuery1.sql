 /*Poizvedbe (select stavki)*/
-- V kolikor naloge ne boš znal rešiti jo lahko preskočiš ali napišeš le delno rešitev.
-- Tabele HumanResources.Employee, Person.Contact, Person.Address, HumanResources.EmployeeAddress

-- 1. Izpiši število zaposlenih v podjetju
select * from Person.Address
SELECT COUNT(*) AS NumberOfEmployees
-- Selecting data from the employees table
FROM HumanResources.Employee

-- 2. Izpiši imena, priimke, naziv delovnega mesta za vse zaposlene

SELECT 
    p.FirstName,
    p.LastName,
    e.JobTitle
FROM 
    Person.Person p
INNER JOIN 
    HumanResources.Employee e ON p.BusinessEntityID = e.BusinessEntityID;

	-- 3. Izpiši imena, priimke, naziv delovnega mesta za vse zaposlene, ki imajo v priimku 'ing'

	SELECT 
    p.FirstName,
    p.LastName,
    e.JobTitle
FROM 
    Person.Person p
	

INNER JOIN 
    HumanResources.Employee e ON p.BusinessEntityID = e.BusinessEntityID
	WHERE 
    p.LastName LIKE '%ing%';

	-- 4. Izpiši vse zaposlene (ime, priimek), ki živijo v mestu Redmond



	SELECT 
    p.FirstName,
    p.LastName


FROM 
    Person.Person p

INNER JOIN 
    HumanResources.Employee e ON p.BusinessEntityID = e.BusinessEntityID
INNER JOIN 
    Person.BusinessEntityAddress bea ON e.BusinessEntityID = bea.BusinessEntityID
INNER JOIN 
    Person.Address a ON bea.AddressID = a.AddressID
WHERE City = 'Redmond';

-- 5. V katerem mestu živi največ zaposlenih in koliko? (napiši query ;))

select TOP 1 a.City,
COUNT(*) as NumberOfEmployees
From HumanResources.Employee p
INNER JOIN 
    HumanResources.Employee e ON p.BusinessEntityID = e.BusinessEntityID
INNER JOIN 
    Person.BusinessEntityAddress bea ON e.BusinessEntityID = bea.BusinessEntityID
INNER JOIN 
    Person.Address a ON bea.AddressID = a.AddressID
GROUP BY a.City
ORDER BY 
   NumberOfEmployees DESC

	-- 6. izpiši zaposlenega (ime priimek, naziv delovnega mesta), ki nima nobenega nadrejenega (direktor)
		SELECT 
    p.FirstName,
    p.LastName,
    e.JobTitle
FROM 
    Person.Person p
	

INNER JOIN 
    HumanResources.Employee e ON p.BusinessEntityID = e.BusinessEntityID 
	WHERE JobTitle = 'Chief Executive Officer';
	---- 7a. Izpiši imena, priimke, naziv delovnega mesta za vse zaposlene (brez direkotrja ).
-- Za vsakega zaposlenega izpiši še, kdo je njegov nadrejeni (ime priimek, naziv delovnega mesta)
-- rezultate uredi po imenu in priimku nadrejenega (padajoče)

SELECT 
    ep.FirstName AS EmployeeFirstName,
    ep.LastName AS EmployeeLastName,
    e.JobTitle AS EmployeeJobTitle,
    mp.FirstName AS ManagerFirstName,
    mp.LastName AS ManagerLastName,
    e.JobTitle AS ManagerJobTitle
FROM 
    HumanResources.Employee e
INNER JOIN 
    Person.Person ep ON e.BusinessEntityID = ep.BusinessEntityID
LEFT JOIN 
    HumanResources.Employee m ON e.BusinessEntityID = m.BusinessEntityID
LEFT JOIN 
    Person.Person mp ON m.BusinessEntityID = mp.BusinessEntityID
WHERE 
    e.BusinessEntityID IS NOT NULL
ORDER BY 
    mp.LastName DESC,
    mp.FirstName DESC;


			SELECT 
    p.FirstName,
    p.LastName,
    e.JobTitle
FROM 
    Person.Person p
	

INNER JOIN 
    HumanResources.Employee e ON p.BusinessEntityID = e.BusinessEntityID 
	

	
	
	WHERE JobTitle != 'Chief Executive Officer'

