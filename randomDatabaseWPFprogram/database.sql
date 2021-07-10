-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 10, 2021 at 07:13 AM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lawfirm`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(255) NOT NULL,
  `login` varchar(255) COLLATE utf8mb4_bin NOT NULL,
  `password` varchar(500) COLLATE utf8mb4_bin NOT NULL,
  `users_info_id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `users_info_id`) VALUES
(1, 'root', '123', 1),
(2, 'user', 'user', 2);

-- --------------------------------------------------------

--
-- Table structure for table `users_documents`
--

CREATE TABLE `users_documents` (
  `document_id` int(255) NOT NULL,
  `title` varchar(255) COLLATE utf8mb4_bin NOT NULL,
  `message` longtext COLLATE utf8mb4_bin NOT NULL,
  `creator_id` int(255) NOT NULL,
  `recipients` varchar(255) COLLATE utf8mb4_bin NOT NULL,
  `creationDate` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `users_documents`
--

INSERT INTO `users_documents` (`document_id`, `title`, `message`, `creator_id`, `recipients`, `creationDate`) VALUES
(1, 'asdasdas', 'asdasdasd', 1, 'Administration,Office', '2021-07-10 07:05:26');

-- --------------------------------------------------------

--
-- Table structure for table `users_info_id`
--

CREATE TABLE `users_info_id` (
  `info_id` int(255) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_bin NOT NULL,
  `surname` varchar(300) COLLATE utf8mb4_bin NOT NULL,
  `phone` varchar(255) COLLATE utf8mb4_bin NOT NULL,
  `role` varchar(255) COLLATE utf8mb4_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `users_info_id`
--

INSERT INTO `users_info_id` (`info_id`, `name`, `surname`, `phone`, `role`) VALUES
(1, 'root', 'root', 'NOT_SET', 'root'),
(2, 'John', 'Doe', 'NOT_SET', 'user\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `user_config`
--

CREATE TABLE `user_config` (
  `config_id` int(255) NOT NULL,
  `theme` varchar(10) COLLATE utf8mb4_bin NOT NULL,
  `lang` varchar(255) COLLATE utf8mb4_bin NOT NULL,
  `user_id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `user_config`
--

INSERT INTO `user_config` (`config_id`, `theme`, `lang`, `user_id`) VALUES
(1, 'dark', 'english', 1),
(2, 'white', 'polish', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `users_info` (`users_info_id`);

--
-- Indexes for table `users_documents`
--
ALTER TABLE `users_documents`
  ADD PRIMARY KEY (`document_id`),
  ADD KEY `users` (`creator_id`);

--
-- Indexes for table `users_info_id`
--
ALTER TABLE `users_info_id`
  ADD PRIMARY KEY (`info_id`);

--
-- Indexes for table `user_config`
--
ALTER TABLE `user_config`
  ADD PRIMARY KEY (`config_id`),
  ADD KEY `userss` (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users_documents`
--
ALTER TABLE `users_documents`
  MODIFY `document_id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users_info_id`
--
ALTER TABLE `users_info_id`
  MODIFY `info_id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `user_config`
--
ALTER TABLE `user_config`
  MODIFY `config_id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_info` FOREIGN KEY (`users_info_id`) REFERENCES `users_info_id` (`info_id`);

--
-- Constraints for table `users_documents`
--
ALTER TABLE `users_documents`
  ADD CONSTRAINT `users` FOREIGN KEY (`creator_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `user_config`
--
ALTER TABLE `user_config`
  ADD CONSTRAINT `userss` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
