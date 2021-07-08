-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 08, 2021 at 11:18 PM
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
  `message` longtext COLLATE utf8mb4_bin NOT NULL,
  `creator_id` int(255) NOT NULL,
  `recipients` longtext COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`recipients`))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `users_documents`
--

INSERT INTO `users_documents` (`document_id`, `message`, `creator_id`, `recipients`) VALUES
(1, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus purus lacus, ultrices ut mollis sed, convallis ac arcu. Sed id vehicula tortor. Aenean sed ante vel nisl aliquam lobortis ut ut purus. Sed quis neque libero. Mauris nunc sem, egestas eu orci ut, efficitur lobortis mauris. Quisque vestibulum vulputate eros eu sodales. Nam faucibus imperdiet magna, eu tristique nibh blandit quis. Phasellus id efficitur lectus. Nullam lacinia quam ut ipsum gravida mattis. Fusce viverra elit at nulla cursus, et aliquam orci euismod. Fusce eget dui vel nunc condimentum luctus sed eu diam. Ut sagittis nulla ipsum, quis fringilla ipsum condimentum eget. Pellentesque laoreet, nulla sit amet euismod convallis, lacus lorem tincidunt elit, ut ornare nunc tellus a arcu.\n\nMaecenas quis libero turpis. Pellentesque tristique imperdiet ante vel dictum. Duis sed odio elit. Vestibulum quis vestibulum magna. Fusce eu dui tellus. Aenean turpis urna, aliquam quis fringilla pellentesque, congue a massa. Aenean elit ex, pellentesque in semper vitae, efficitur bibendum diam. Nulla arcu risus, elementum sit amet eros eget, convallis varius odio. Maecenas egestas ex tempus ipsum sollicitudin, a porttitor dui efficitur. Donec laoreet nisi ac euismod posuere. Nullam commodo quis sem in vehicula. Suspendisse et nisl nec risus consequat aliquet. Phasellus vitae vehicula arcu, sed interdum ex.\n\nAliquam imperdiet, velit sed scelerisque consectetur, elit massa mattis ex, id posuere erat metus imperdiet neque. Duis non justo efficitur, sodales ipsum vitae, commodo ligula. Nulla facilisi. Maecenas gravida lectus leo, vel volutpat libero fermentum quis. Duis at metus sed tortor dictum fringilla. Suspendisse lorem purus, tempus eget rutrum in, scelerisque non arcu. In tempor ante at finibus laoreet.\n\nMaecenas tristique imperdiet sem, quis hendrerit nulla dapibus vel. Etiam quis erat ut justo porta volutpat vitae sit amet tortor. Sed arcu odio, condimentum id eleifend vel, ornare eu risus. Quisque nec dolor at nibh sollicitudin dapibus. Curabitur aliquam augue pretium aliquam luctus. Aliquam erat volutpat. Curabitur semper mauris metus, quis bibendum justo sollicitudin sed. Proin id efficitur tellus.\n\nDonec justo ante, finibus eget ex at, ornare iaculis massa. Donec blandit pharetra velit eu auctor. Nulla facilisi. Donec et odio quis libero laoreet placerat tempor a diam. Nulla magna augue, euismod vel lacinia eu, finibus ut magna. Nam scelerisque, ante vel posuere tempor, mi erat dignissim ipsum, ac tincidunt libero arcu in risus. Donec et tempus nibh, non vestibulum sem. Aliquam consectetur porta ante, a efficitur justo convallis id. Donec id sollicitudin nibh. In ut ipsum tellus. Nam dolor magna, sodales a nulla id, congue vulputate justo. Aenean vel eleifend felis, quis pharetra leo.\n\nCras lorem eros, sollicitudin non suscipit ac, semper bibendum ante. Nam eu dapibus nulla. Aenean egestas dui in lacus dignissim, quis tincidunt dui tincidunt. Maecenas volutpat rutrum neque vitae tincidunt. Proin gravida ornare nunc ut suscipit. Quisque tristique felis nec enim scelerisque, nec sollicitudin sem aliquam. Pellentesque nibh neque, consectetur eu rutrum et, aliquet ut ex. Ut vitae mollis felis.\n\nMaecenas ornare vitae sapien et malesuada. Etiam tempor, ex vel semper varius, massa erat placerat turpis, at eleifend nibh est eget est. Donec cursus sem quis diam suscipit, suscipit faucibus quam hendrerit. Sed congue arcu enim, id volutpat ex tincidunt non. Fusce sodales venenatis leo faucibus fermentum. Etiam eu enim vel nisl eleifend scelerisque et eu eros. Vivamus feugiat, purus et consectetur pretium, lacus sapien ultricies lacus, sed sollicitudin metus lorem vitae dui. Sed ultricies congue nibh vel pulvinar. Mauris turpis turpis, vehicula feugiat pulvinar et, faucibus eu urna. Integer ut congue diam. In elit dolor, venenatis consectetur finibus in, aliquet id justo. Mauris facilisis scelerisque nisi eget placerat. Vestibulum bibendum ligula tellus, a ultrices odio facilisis in. Nullam quis euismod mi, a lacinia turpis.\n\nPellentesque at erat nibh. Phasellus maximus sit amet magna sit amet vulputate. Donec non orci vitae urna iaculis pellentesque non sed eros. Mauris id ligula nisl. Aliquam magna justo, eleifend at enim ut, vehicula gravida purus. In leo quam, facilisis at fringilla vel, congue vel justo. Aliquam ante mauris, scelerisque vitae pretium eu, faucibus luctus mauris.\n\nDonec eget nunc eros. Mauris lectus nibh, pulvinar eget tempus ac, condimentum ut ante. Fusce bibendum varius mauris, vel aliquet ante viverra ac. Integer eu odio tincidunt, volutpat enim ac, viverra sapien. Duis tempor vehicula dolor non dignissim. Nam vehicula mi ut turpis tristique facilisis sit amet at magna. Aenean non egestas urna.\n\nSuspendisse feugiat enim eu purus consequat finibus. Donec tristique est magna, vitae facilisis diam vehicula quis. Mauris elementum feugiat neque, ut consequat magna pellentesque non. Nunc ut turpis scelerisque, luctus metus sollicitudin, molestie erat vel. ', 1, '{\n\"recipients\":[\"Administration\", \"Office\", \"Customers\"]\n}');

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
(2, 'user', 'user', 'user', 'user\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `user_theme_config`
--

CREATE TABLE `user_theme_config` (
  `config_id` int(255) NOT NULL,
  `theme` varchar(10) COLLATE utf8mb4_bin NOT NULL,
  `user_id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `user_theme_config`
--

INSERT INTO `user_theme_config` (`config_id`, `theme`, `user_id`) VALUES
(1, 'dark', 1),
(2, 'white', 2);

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
-- Indexes for table `user_theme_config`
--
ALTER TABLE `user_theme_config`
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
-- AUTO_INCREMENT for table `user_theme_config`
--
ALTER TABLE `user_theme_config`
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
-- Constraints for table `user_theme_config`
--
ALTER TABLE `user_theme_config`
  ADD CONSTRAINT `userss` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
