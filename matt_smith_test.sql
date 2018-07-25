-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 25, 2018 at 11:42 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `matt_smith_test`
--
CREATE DATABASE IF NOT EXISTS `matt_smith_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `matt_smith_test`;

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
(65, 'Bob', 0);

-- --------------------------------------------------------

--
-- Table structure for table `clients_stylists`
--

CREATE TABLE `clients_stylists` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
(1, 1, 2),
(2, 2, 3),
(3, 7, 5),
(4, 8, 6),
(5, 13, 8),
(6, 14, 9),
(7, 19, 11),
(8, 20, 12),
(9, 25, 14),
(10, 26, 15),
(11, 31, 17),
(12, 32, 18),
(13, 37, 20),
(14, 38, 21),
(15, 43, 23),
(16, 44, 24),
(17, 49, 25),
(19, 53, 28),
(20, 54, 29),
(21, 59, 30),
(23, 63, 33),
(24, 64, 34),
(25, 69, 35),
(27, 73, 38),
(28, 74, 39),
(29, 79, 40),
(31, 87, 42),
(38, 107, 52),
(39, 108, 53);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;

--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=159;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
