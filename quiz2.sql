-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 24 Jan 2021 pada 05.15
-- Versi Server: 10.1.29-MariaDB
-- PHP Version: 7.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quiz2`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `barang`
--

CREATE TABLE `barang` (
  `idbarang` int(11) NOT NULL,
  `kode_barang` int(11) NOT NULL,
  `nama_barang` varchar(255) NOT NULL,
  `satuan` varchar(255) NOT NULL,
  `stok` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barang`
--

INSERT INTO `barang` (`idbarang`, `kode_barang`, `nama_barang`, `satuan`, `stok`) VALUES
(1010, 99, 'HP Asus ROG', 'PCS', 1000),
(1111, 100, 'HP VIVO V20', 'PCS', 1000),
(11110, 101, 'OPPO RENO 4', 'PCS', 10000),
(11111, 102, 'vivo Y17', 'DUS', 10000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangkeluar`
--

CREATE TABLE `barangkeluar` (
  `idkeluar` int(11) NOT NULL,
  `nomor_bukti` varchar(255) NOT NULL,
  `tanggal` date NOT NULL,
  `namastaff_toko` varchar(255) NOT NULL,
  `namastaff_gudang` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangkeluar`
--

INSERT INTO `barangkeluar` (`idkeluar`, `nomor_bukti`, `tanggal`, `namastaff_toko`, `namastaff_gudang`) VALUES
(103, '90511106', '2021-01-29', 'Hady', 'Romi'),
(1100, '90511103', '2021-01-20', 'Aziz Salahuddin', 'Adly M D'),
(1101, '90511104', '2021-01-28', 'Aziz Salahuddin', 'Adly M D'),
(1102, '90511105', '2021-01-27', 'Salas DN', 'EKO');

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangkeluar_detail`
--

CREATE TABLE `barangkeluar_detail` (
  `idkdetail` int(11) NOT NULL,
  `nomor_bukti` varchar(255) NOT NULL,
  `kode_barang` int(11) NOT NULL,
  `nama_barang` varchar(255) NOT NULL,
  `qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangkeluar_detail`
--

INSERT INTO `barangkeluar_detail` (`idkdetail`, `nomor_bukti`, `kode_barang`, `nama_barang`, `qty`) VALUES
(0, '', 0, '', 0),
(1100, '90511103', 99, 'HP Asus ROG', 999),
(1101, '90511104', 100, 'Vivo V20', 999),
(1102, '90511105', 101, 'OPPO Reno 4', 9999),
(1103, '90511106', 102, 'Vivo Y17', 9999);

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangmasuk`
--

CREATE TABLE `barangmasuk` (
  `idamasuk` int(11) NOT NULL,
  `nomor_faktur` varchar(255) NOT NULL,
  `kode_supplier` varchar(20) NOT NULL,
  `tanggal` varchar(30) NOT NULL,
  `nama_penerima` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangmasuk`
--

INSERT INTO `barangmasuk` (`idamasuk`, `nomor_faktur`, `kode_supplier`, `tanggal`, `nama_penerima`) VALUES
(9090, '1905111', '909', '2021-01-20', 'RISKI'),
(9091, '1905112', '910', '2021-01-22', 'RIFKI'),
(9092, '1905113', '911', '2021-01-25', 'ERLIN');

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangmasuk_detail`
--

CREATE TABLE `barangmasuk_detail` (
  `idmdetail` int(11) NOT NULL,
  `nomor_faktur` varchar(30) NOT NULL,
  `kode_barang` int(11) NOT NULL,
  `nama_barang` varchar(255) NOT NULL,
  `qty` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangmasuk_detail`
--

INSERT INTO `barangmasuk_detail` (`idmdetail`, `nomor_faktur`, `kode_barang`, `nama_barang`, `qty`) VALUES
(9090, '1905111', 99, 'HP Asus ROG\r\n', '10'),
(9091, '1905111', 100, 'HP Vivo Y20', ''),
(9092, '1905113', 102, 'Vivo Y17', '10');

-- --------------------------------------------------------

--
-- Struktur dari tabel `supplier`
--

CREATE TABLE `supplier` (
  `idsupplier` int(11) NOT NULL,
  `kode_supplier` varchar(30) NOT NULL,
  `nama_supplier` varchar(255) NOT NULL,
  `kontak_person` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `supplier`
--

INSERT INTO `supplier` (`idsupplier`, `kode_supplier`, `nama_supplier`, `kontak_person`, `email`) VALUES
(900, '1001', 'REFKA', '089992999', 'refkaanelka@gmaill.com'),
(901, '1002', 'Nana', '083161716', 'nanar@gmail.com');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `iduser` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `nama_lengkap` varchar(255) NOT NULL,
  `passwd` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`iduser`, `username`, `nama_lengkap`, `passwd`) VALUES
(1900, 'Admin', 'Admin', '827ccb0eea8a706c4c34a16891f84e7b'),
(1901, 'Ahmad', 'Achmad Saefudin', '202cb962ac59075b964b07152d234b70'),
(1902, 'Aziz', 'Abdul Aziz', 'ec46993a71b78852d2c1be0be6005602'),
(1903, 'Hadi', 'Hamam Hadi', 'e2fb583d6b3828b6ae32615c3f540f70');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`idbarang`);

--
-- Indexes for table `barangkeluar`
--
ALTER TABLE `barangkeluar`
  ADD PRIMARY KEY (`idkeluar`);

--
-- Indexes for table `barangkeluar_detail`
--
ALTER TABLE `barangkeluar_detail`
  ADD PRIMARY KEY (`idkdetail`);

--
-- Indexes for table `barangmasuk`
--
ALTER TABLE `barangmasuk`
  ADD PRIMARY KEY (`idamasuk`);

--
-- Indexes for table `barangmasuk_detail`
--
ALTER TABLE `barangmasuk_detail`
  ADD PRIMARY KEY (`idmdetail`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`idsupplier`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`iduser`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
