-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 26, 2024 at 12:38 PM
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

-- --------------------------------------------------------

--
-- Table structure for table `pravo`
--

CREATE TABLE `pravo` (
  `id` int(11) NOT NULL,
  `zaposlenik_id` int(11) DEFAULT NULL,
  `pravo_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
(1, '111', '1', 1.00, 10, 5, 1),
(2, '2', '2', 2.00, 219, 22, 1);

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
(9, 1, '2024-02-26 12:35:29');

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
(9, 9, 4);

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
(5, 1, -3, 1.00, 7);

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
(1, '1', '1', '1', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 0);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pravo`
--
ALTER TABLE `pravo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `proizvodi`
--
ALTER TABLE `proizvodi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `racun`
--
ALTER TABLE `racun`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `status`
--
ALTER TABLE `status`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `status_racuna`
--
ALTER TABLE `status_racuna`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `stavkaracuna`
--
ALTER TABLE `stavkaracuna`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `zaposlenici`
--
ALTER TABLE `zaposlenici`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
