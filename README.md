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
`CREATE TABLE clients_stylists (id serial PRIMARY KEY, nstylist_id INT, client_id INT)`

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
