-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 24 Jan 2021 pada 22.42
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
-- Database: `gudang1`
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
(1, 10, 'Vivo V20', 'PCS', 100),
(2, 11, 'Vivo Y19', 'PCS', 100);

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangkeluar`
--

CREATE TABLE `barangkeluar` (
  `idkeluar` int(11) NOT NULL,
  `nomor_bukti` varchar(255) NOT NULL,
  `tanggal` varchar(30) NOT NULL,
  `namastaff_toko` varchar(255) NOT NULL,
  `namastaff_gudang` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangkeluar`
--

INSERT INTO `barangkeluar` (`idkeluar`, `nomor_bukti`, `tanggal`, `namastaff_toko`, `namastaff_gudang`) VALUES
(1, '1905111', '2021-01-20', 'Aziz S', 'Sanpria'),
(2, '1905112', '2021-01-22', 'Eko', 'Supriyatno');

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
(1, '1905111', 10, 'Vivo V20', 100),
(2, '1905112', 11, 'Vivo Y19', 100),
(0, '1905111', 10, '', 100);

-- --------------------------------------------------------

--
-- Struktur dari tabel `barangmasuk`
--

CREATE TABLE `barangmasuk` (
  `idmasuk` int(11) NOT NULL,
  `nomor_faktur` varchar(255) NOT NULL,
  `kode_supplier` varchar(20) NOT NULL,
  `tanggal` varchar(30) NOT NULL,
  `nama_penerima` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `barangmasuk`
--

INSERT INTO `barangmasuk` (`idmasuk`, `nomor_faktur`, `kode_supplier`, `tanggal`, `nama_penerima`) VALUES
(1, '9051116', '01', '2021-01-27', 'Hamam'),
(2, '9051117', '02', '2021-01-29', 'Rofiful');

-- --------------------------------------------------------

--
-- Struktur dari tabel `bmdetail`
--

CREATE TABLE `bmdetail` (
  `idmd` int(11) NOT NULL,
  `nomor_faktur` varchar(30) NOT NULL,
  `kode_barang` int(11) NOT NULL,
  `nama_barang` varchar(255) NOT NULL,
  `qty` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `bmdetail`
--

INSERT INTO `bmdetail` (`idmd`, `nomor_faktur`, `kode_barang`, `nama_barang`, `qty`) VALUES
(1, '9051116', 10, '', '100'),
(2, '9051117', 11, 'Vivo Y19', '100');

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
(1, '10', 'Sampria', '089524541116', 'Sampria@gmail.com'),
(2, '11', 'Nugraha', '089542541117', 'Nugraha@gmail.com');

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
(1, 'admin', 'Admin', '202cb962ac59075b964b07152d234b70'),
(2, 'Staff', 'SAM', '202cb962ac59075b964b07152d234b70');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`idbarang`);

--
-- Indexes for table `bmdetail`
--
ALTER TABLE `bmdetail`
  ADD PRIMARY KEY (`idmd`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
