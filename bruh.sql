-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 10, 2024 at 12:02 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bruh`
--

-- --------------------------------------------------------

--
-- Table structure for table `dobavljaci`
--

CREATE TABLE `dobavljaci` (
  `id` int(11) NOT NULL,
  `naziv` varchar(255) NOT NULL,
  `adresa` varchar(255) NOT NULL,
  `kontakt` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dobavljaci`
--

INSERT INTO `dobavljaci` (`id`, `naziv`, `adresa`, `kontakt`) VALUES
(1, '1', '1', '1');

-- --------------------------------------------------------

--
-- Table structure for table `prava`
--

CREATE TABLE `prava` (
  `id` int(11) NOT NULL,
  `pravo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prava`
--

INSERT INTO `prava` (`id`, `pravo`) VALUES
(1, 'blagajna'),
(3, 'dobavljaci'),
(4, 'proizvodi'),
(5, 'racuni'),
(2, 'zaposlenici');

-- --------------------------------------------------------

--
-- Table structure for table `pravo`
--

CREATE TABLE `pravo` (
  `id` int(11) NOT NULL,
  `zaposlenik_id` int(11) DEFAULT NULL,
  `pravo_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pravo`
--

INSERT INTO `pravo` (`id`, `zaposlenik_id`, `pravo_id`) VALUES
(19, 2, 3),
(20, 2, 4),
(21, 2, 5),
(22, 1, 1),
(23, 1, 3),
(24, 1, 4),
(25, 1, 5),
(27, 1, 2),
(34, 4, 1),
(35, 4, 4),
(36, 3, 1),
(37, 3, 3),
(38, 3, 4),
(39, 3, 5);

-- --------------------------------------------------------

--
-- Table structure for table `proizvodi`
--

CREATE TABLE `proizvodi` (
  `id` int(11) NOT NULL,
  `barcode` varchar(255) NOT NULL,
  `naziv` varchar(255) NOT NULL,
  `cijena` decimal(10,2) NOT NULL,
  `kol_na_sklad` int(11) NOT NULL,
  `min_kol` int(11) NOT NULL,
  `dobavljac_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `proizvodi`
--

INSERT INTO `proizvodi` (`id`, `barcode`, `naziv`, `cijena`, `kol_na_sklad`, `min_kol`, `dobavljac_id`) VALUES
(1, '111', '1', 1.00, 5, 5, 1),
(2, '2', '2', 2.00, 217, 22, 1);

-- --------------------------------------------------------

--
-- Table structure for table `racun`
--

CREATE TABLE `racun` (
  `id` int(11) NOT NULL,
  `zaposlenik_id` int(11) DEFAULT NULL,
  `datum_izdavanja` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `racun`
--

INSERT INTO `racun` (`id`, `zaposlenik_id`, `datum_izdavanja`) VALUES
(1, 1, '2024-02-26 12:27:48'),
(2, 1, '2024-02-26 12:29:24'),
(3, 1, '2024-02-26 12:29:49'),
(4, 1, '2024-02-26 12:30:59'),
(5, 1, '2024-02-26 12:32:24'),
(6, 1, '2024-02-26 12:33:56'),
(7, 1, '2024-02-26 12:34:25'),
(8, 1, '2024-02-26 12:34:25'),
(9, 1, '2024-02-26 12:35:29'),
(10, 1, '2024-02-26 12:50:27'),
(11, 1, '2024-02-26 12:51:40'),
(12, 1, '2024-02-26 12:52:38'),
(13, 1, '2024-02-26 12:54:32'),
(14, 1, '2024-04-05 12:54:03'),
(15, 1, '2024-04-05 12:54:06'),
(16, 1, '2024-04-05 12:54:07'),
(17, 1, '2024-04-05 12:54:09'),
(18, 1, '2024-04-05 12:54:10'),
(19, 1, '2024-04-05 13:01:09'),
(20, 1, '2024-04-05 13:02:58'),
(21, 1, '2024-04-05 13:18:15'),
(22, 1, '2024-04-05 13:19:20'),
(23, 1, '2024-04-09 22:47:47'),
(24, 1, '2024-04-09 22:47:51'),
(25, 1, '2024-04-09 22:57:08'),
(27, 1, '2024-04-09 23:01:58'),
(28, 1, '2024-04-09 23:02:44'),
(29, 1, '2024-04-09 23:05:28'),
(30, 1, '2024-04-09 23:08:37'),
(31, 1, '2024-04-09 23:09:59'),
(32, 1, '2024-04-09 23:09:59'),
(33, 1, '2024-04-09 23:13:14'),
(34, 1, '2024-04-09 23:16:30'),
(35, 1, '2024-04-09 23:20:04'),
(36, 1, '2024-04-09 23:21:34'),
(37, 1, '2024-04-09 23:22:41'),
(38, 1, '2024-04-09 23:24:23'),
(39, 1, '2024-04-09 23:25:42'),
(40, 1, '2024-04-09 23:27:01'),
(41, 1, '2024-04-09 23:27:15'),
(42, 1, '2024-04-09 23:28:50'),
(43, 2, '2024-04-09 23:29:31'),
(44, 2, '2024-04-09 23:29:54'),
(45, 1, '2024-04-09 23:40:22'),
(46, 2, '2024-04-09 23:40:41'),
(47, 2, '2024-04-09 23:46:01'),
(48, 1, '2024-04-09 23:49:29'),
(49, 2, '2024-04-09 23:50:29'),
(50, 1, '2024-04-09 23:51:10'),
(51, 1, '2024-04-09 23:51:18'),
(52, 1, '2024-04-09 23:51:37'),
(53, 3, '2024-04-09 23:52:26'),
(54, 1, '2024-04-09 23:53:22'),
(55, 3, '2024-04-09 23:54:09'),
(56, 1, '2024-04-09 23:55:29'),
(57, 3, '2024-04-09 23:55:38'),
(58, 3, '2024-04-09 23:56:51'),
(59, 4, '2024-04-09 23:59:16'),
(60, 4, '2024-04-09 23:59:42');

-- --------------------------------------------------------

--
-- Table structure for table `status`
--

CREATE TABLE `status` (
  `id` int(11) NOT NULL,
  `status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `status`
--

INSERT INTO `status` (`id`, `status`) VALUES
(1, 'cekanje'),
(4, 'odbaceno'),
(2, 'placeno'),
(3, 'stornirano');

-- --------------------------------------------------------

--
-- Table structure for table `status_racuna`
--

CREATE TABLE `status_racuna` (
  `id` int(11) NOT NULL,
  `racun_id` int(11) DEFAULT NULL,
  `status_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `status_racuna`
--

INSERT INTO `status_racuna` (`id`, `racun_id`, `status_id`) VALUES
(5, 5, 3),
(6, 6, 4),
(7, 7, 2),
(8, 8, 4),
(9, 9, 4),
(10, 10, 4),
(11, 11, 4),
(12, 12, 4),
(13, 13, 4),
(14, 14, 4),
(15, 15, 4),
(16, 16, 4),
(17, 17, 4),
(18, 18, 4),
(19, 19, 4),
(20, 20, 4),
(21, 21, 4),
(22, 22, 4),
(23, 23, 4),
(24, 24, 4),
(25, 25, 4),
(27, 27, 4),
(28, 28, 4),
(29, 29, 4),
(30, 30, 4),
(31, 31, 2),
(32, 32, 4),
(33, 33, 4),
(34, 34, 4),
(35, 35, 4),
(36, 36, 4),
(37, 37, 4),
(38, 38, 4),
(39, 39, 4),
(40, 40, 4),
(41, 41, 4),
(42, 42, 4),
(43, 43, 4),
(44, 44, 4),
(45, 45, 4),
(46, 46, 4),
(47, 47, 4),
(48, 48, 4),
(49, 49, 4),
(50, 50, 4),
(51, 51, 4),
(52, 52, 4),
(53, 53, 4),
(54, 54, 4),
(55, 55, 4),
(56, 56, 4),
(57, 57, 4),
(58, 58, 4),
(59, 59, 4),
(60, 60, 4);

-- --------------------------------------------------------

--
-- Table structure for table `stavkaracuna`
--

CREATE TABLE `stavkaracuna` (
  `id` int(11) NOT NULL,
  `proizvod_id` int(11) DEFAULT NULL,
  `kolicina` int(11) DEFAULT NULL,
  `cijena_po_jedinici` decimal(10,2) DEFAULT NULL,
  `racun_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `stavkaracuna`
--

INSERT INTO `stavkaracuna` (`id`, `proizvod_id`, `kolicina`, `cijena_po_jedinici`, `racun_id`) VALUES
(1, 1, 100, 1.00, 3),
(2, 2, 10, 2.00, 5),
(3, 1, 3, 1.00, 7),
(4, 2, 3, 2.00, 7),
(5, 1, -3, 1.00, 7),
(6, 1, 5, 1.00, 31),
(7, 2, 2, 2.00, 31);

-- --------------------------------------------------------

--
-- Table structure for table `zaposlenici`
--

CREATE TABLE `zaposlenici` (
  `id` int(11) NOT NULL,
  `ime` varchar(255) NOT NULL,
  `prezime` varchar(255) NOT NULL,
  `korisnicko_ime` varchar(255) NOT NULL,
  `lozinka` varchar(255) NOT NULL,
  `prva_prijava` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `zaposlenici`
--

INSERT INTO `zaposlenici` (`id`, `ime`, `prezime`, `korisnicko_ime`, `lozinka`, `prva_prijava`) VALUES
(1, '1', '1', '1', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 0),
(2, 'Noa', 'Turk', 'Turk', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 0),
(3, 'tri', 'tri', 'tri', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 0),
(4, '44', '44', '44', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dobavljaci`
--
ALTER TABLE `dobavljaci`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `prava`
--
ALTER TABLE `prava`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `pravo` (`pravo`);

--
-- Indexes for table `pravo`
--
ALTER TABLE `pravo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `zaposlenik_id` (`zaposlenik_id`),
  ADD KEY `pravo_id` (`pravo_id`);

--
-- Indexes for table `proizvodi`
--
ALTER TABLE `proizvodi`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dobavljac_id` (`dobavljac_id`);

--
-- Indexes for table `racun`
--
ALTER TABLE `racun`
  ADD PRIMARY KEY (`id`),
  ADD KEY `zaposlenik_id` (`zaposlenik_id`);

--
-- Indexes for table `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `status` (`status`);

--
-- Indexes for table `status_racuna`
--
ALTER TABLE `status_racuna`
  ADD PRIMARY KEY (`id`),
  ADD KEY `racun_id` (`racun_id`),
  ADD KEY `status_id` (`status_id`);

--
-- Indexes for table `stavkaracuna`
--
ALTER TABLE `stavkaracuna`
  ADD PRIMARY KEY (`id`),
  ADD KEY `proizvod_id` (`proizvod_id`),
  ADD KEY `racun_id` (`racun_id`);

--
-- Indexes for table `zaposlenici`
--
ALTER TABLE `zaposlenici`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `korisnicko_ime` (`korisnicko_ime`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dobavljaci`
--
ALTER TABLE `dobavljaci`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `prava`
--
ALTER TABLE `prava`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `pravo`
--
ALTER TABLE `pravo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `proizvodi`
--
ALTER TABLE `proizvodi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `racun`
--
ALTER TABLE `racun`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `status`
--
ALTER TABLE `status`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `status_racuna`
--
ALTER TABLE `status_racuna`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `stavkaracuna`
--
ALTER TABLE `stavkaracuna`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `zaposlenici`
--
ALTER TABLE `zaposlenici`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pravo`
--
ALTER TABLE `pravo`
  ADD CONSTRAINT `pravo_ibfk_1` FOREIGN KEY (`zaposlenik_id`) REFERENCES `zaposlenici` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `pravo_ibfk_2` FOREIGN KEY (`pravo_id`) REFERENCES `prava` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `proizvodi`
--
ALTER TABLE `proizvodi`
  ADD CONSTRAINT `proizvodi_ibfk_1` FOREIGN KEY (`dobavljac_id`) REFERENCES `dobavljaci` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `racun`
--
ALTER TABLE `racun`
  ADD CONSTRAINT `racun_ibfk_1` FOREIGN KEY (`zaposlenik_id`) REFERENCES `zaposlenici` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `status_racuna`
--
ALTER TABLE `status_racuna`
  ADD CONSTRAINT `status_racuna_ibfk_1` FOREIGN KEY (`racun_id`) REFERENCES `racun` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `status_racuna_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `status` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `stavkaracuna`
--
ALTER TABLE `stavkaracuna`
  ADD CONSTRAINT `stavkaracuna_ibfk_1` FOREIGN KEY (`proizvod_id`) REFERENCES `proizvodi` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `stavkaracuna_ibfk_2` FOREIGN KEY (`racun_id`) REFERENCES `racun` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
