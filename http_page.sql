-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 07, 2019 at 04:57 AM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `http_page`
--

-- --------------------------------------------------------

--
-- Table structure for table `places`
--

CREATE TABLE `places` (
  `place_id` int(11) NOT NULL,
  `place_title` varchar(50) NOT NULL,
  `place_description` varchar(2000) NOT NULL,
  `created_on` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `places`
--

INSERT INTO `places` (`place_id`, `place_title`, `place_description`, `created_on`) VALUES
(1, 'Etobicoke', 'Suburban Etobicoke is home to several lakefront parks, golf courses, and vast Centennial Park, with a conservatory featuring tropical plants. The 1830s Montgomery’s Inn has a museum, tea room, and pub and hosts a weekly farmers’ market. Islington - City Centre West area is a busy commercial hub, containing shopping complexes and casual chain eateries, plus history-themed murals along Dundas Street West.', '2020-10-05 08:48:24'),
(2, 'Brampton', 'Brampton is a Canadian city in Ontario’s Greater Toronto Area. Its Peel Art Gallery, Museum and Archives is housed in 19th-century and contemporary buildings. In the center of downtown is the Rose Theatre, a major performing arts venue. In front, Garden Square hosts big-screen movies and live events. Green spaces include Gage Park with its floral gardens. To the north sits Historic Bovaird House, a Victorian home.', '2020-10-26 13:28:09'),
(3, 'Mississauga\'dwv', 'Mississauga is a large Canadian city neighbouring Toronto on Lake Ontario. On the lakefront, Port Credit has shops, a working lighthouse and a marina with a grounded freighter. Multi-use trails wind through the city\'s parks and woodlands. In the centre, Mississauga Celebration Square hosts multicultural festivals and has a skating rink in winter. A popular shopping destination, the city has several huge malls.', '2020-01-14 14:14:55'),
(4, 'Downtown Toronto', 'Downtown Toronto is the main central business district of Toronto, Ontario, Canada. Located entirely within the district of Old Toronto, it is approximately 17 square kilometers in area, bounded by Bloor Street to the northeast and Dupont Street to the northwest, Lake Ontario to the south, the Don Valley to the east, and Bathurst Street to the west. It is also the location of the City of Toronto government and the Government of Ontario.', '2019-08-29 20:53:42'),
(5, 'Ajax', 'Ajax is a town in Durham Region in Southern Ontario, Canada, located in the eastern part of the Greater Toronto Area. The town is named for HMS Ajax, a Royal Navy cruiser that served in World War', '2020-05-24 22:44:01'),
(6, 'Mumbaiiiiiiiiiiiiiiiii', 'Mumbai (formerly called Bombay) is a densely populated city on India’s west coast. A financial center, it\'s India\'s largest city. On the Mumbai Harbour waterfront stands the iconic Gateway of India stone arch, built by the British Raj in 1924. Offshore, nearby Elephanta Island holds ancient cave temples dedicated to the Hindu god Shiva. The city\'s also famous as the heart of the Bollywood film industry.', '2019-01-22 06:17:17'),
(7, 'Bengaluru', 'Bengaluru (also called Bangalore) is the capital of India\'s southern Karnataka state. The center of India\'s high-tech industry, the city is also known for its parks and nightlife. By Cubbon Park, Vidhana Soudha is a Neo-Dravidian legislative building. Former royal residences include 19th-century Bangalore Palace, modeled after England’s Windsor Castle, and Tipu Sultan’s Summer Palace, an 18th-century teak structure.', '2019-12-06 14:47:54');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `places`
--
ALTER TABLE `places`
  ADD PRIMARY KEY (`place_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `places`
--
ALTER TABLE `places`
  MODIFY `place_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
