# Hair Salon

#### Epicodus C# code review #3, 07.13.18

#### By Matt Smith

## Description

A .NET web app that allows the owner of a salon to add stylists and the stylist's respective clients.

## User Stories

* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.
* As an employee, I need to be able to delete stylists (all and single).
* As an employee, I need to be able to delete clients (all and single).
* As an employee, I need to be able to view clients (all and single).
* As an employee, I need to be able to edit JUST the name of a stylist. (You can choose to allow employees to edit additional properties but it is not required.)
* As an employee, I need to be able to edit ALL of the information for a client.
* As an employee, I need to be able to add a specialty and view all specialties that have been added.
* As an employee, I need to be able to add a specialty to a stylist.
* As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
* As an employee, I need to see the stylist's specialties on the stylist's details page.
* As an employee, I need to be able to add a stylist to a specialty.


## Setup on OSX

* Download and install .Net Core 1.1.4
* Download and install Mono
* Download and install MAMP 4.5
* Clone the repo
* Open MAMP and start servers
* Set up database:  
`CREATE DATABASE matt_smith`   
`USE matt_smith`  
`CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT)`  
`CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), client_id INT)`  
`CREATE TABLE clients_stylists (id serial PRIMARY KEY, stylist_id INT, client_id INT)`  
`CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255)`  
`CREATE TABLE specialties_stylists (id serial PRIMARY KEY, stylist_id INT, specialty_id INT)`


* Run `dotnet restore` from project directory and test directory to install packages
* Run `dotnet build` from project directory and fix any build errors
* Run `dotnet test` from the test directory to run the testing suite
* Run `dotnet run` to run application



## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4
* MAMP 4.5
* MySql
* Bootstrap 3.3.7

## Links

* https://github.com/MattSmithereens/HairSalon

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Matt Smith**
