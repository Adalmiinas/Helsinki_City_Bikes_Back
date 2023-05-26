# Helsinki Bikes - Backend

## Table of Contents
1. [Introduction](#intro)
2. [Feature](#feats)
3. [Technologies](#tech)
4. [Usage](#use)
5. [Authors](#aut)
6. [Sources](#sou)


## 1. Introduction 
This is the backend of the Solita dev-academy pre-assignment. The project mission is to display journeys made with the city bikes in Helsinki.

The Frontend can be found here: https://github.com/Adalmiinas/Helsinki_City_Bikes_Front

## 2. Features
* Creates a database
* Imports data 
* Validated data before importing
* Api endpoints 

## 3. Technologies 
* ASP.NET 6
* C#
* SSMS

## 4. Usage

Download Visual Studio and SQL Service Management Studio (SSMS). Find your information for the connection string.
dotnet watch run to download all the nuget packages

Change your connection string in app.config file. 

```javascript
<?xml version="1.0" encoding="utf-8"?>
<configuration>
	<connectionStrings>
		<add name="helsinkiBikes" connectionString="Add your connection string here" />
	</connectionStrings>
</configuration>
```

Uncomment the seeding commands from Program.cs file.

Windows: Open package Management console in Visual Studio and run: 
### `update-database` 

Mac: Open terminal and run (you might have to configure entity framework commands): 
### `dotnet ef database update` 

After it has created the tables run 
### `dotnet watch run` 
and terminate it with crtl + C. While it's shutting down it imports the data. Because of the size of the files this might take several minutes. You can discontinue it early with ctrl + C again.

Recomment the seeding commands before running again with:
### `dotnet watch run` 

While the program is running you can see the api at: https://localhost:7183/index.html or https://localhost:7183/swagger/index.html

While both backend and frontend are running you can view the application at: http://localhost:3000/


## 5. Authors
[@Adalmiina](https://github.com/Adalmiinas)


## 6. Sources
License and information of the Data used in the project: https://www.avoindata.fi/data/en/dataset/hsl-n-kaupunkipyoraasemat/resource/a23eef3a-cc40-4608-8aa2-c730d17e8902

Logo used in the project: https://fi.wikipedia.org/wiki/Tiedosto:HSL_logo.svg