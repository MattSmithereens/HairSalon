-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 25, 2018 at 11:40 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `matt_smith`
--
CREATE DATABASE IF NOT EXISTS `matt_smith` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `matt_smith`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`, `stylist_id`) VALUES
(3, 'Tyra Banks', 0),
(4, 'Lady Gaga', 0);

-- --------------------------------------------------------

--
-- Table structure for table `clients_stylists`
--

CREATE TABLE `clients_stylists` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients_stylists`
--

INSERT INTO `clients_stylists` (`id`, `stylist_id`, `client_id`) VALUES
(5, 2, 3);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `name`) VALUES
(8, 'mohawks'),
(9, 'facials'),
(10, 'dredlocks');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylists`
--

CREATE TABLE `specialties_stylists` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylists`
--

INSERT INTO `specialties_stylists` (`id`, `stylist_id`, `specialty_id`) VALUES
(1, 1, 1),
(2, 1, 4),
(4, 1, 8),
(5, 2, 8);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `client_id`) VALUES
(1, 'Brutus', 0),
(2, 'Turd Fergusson', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
