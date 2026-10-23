-- ============================================
-- Script para crear la base de datos
-- Tienda Vocaloid
-- ============================================

-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS tiendavocaloid;
USE tiendavocaloid;

-- Crear la tabla Producto
CREATE TABLE IF NOT EXISTS Producto (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Categoria VARCHAR(50) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Descripcion TEXT
);

-- Insertar productos de ejemplo
INSERT INTO Producto (Nombre, Precio, Categoria, Stock, Descripcion) VALUES
('Hatsune Miku V4X', 15000, 'Voicebank', 25, 'Voicebank oficial de Hatsune Miku con soporte japonés e inglés'),
('Kagamine Rin/Len V4X', 12000, 'Voicebank', 18, 'Pack de los gemelos Kagamine con voces mejoradas'),
('Megurine Luka V4X', 13000, 'Voicebank', 12, 'Voicebank de Luka con estilo maduro y elegante'),
('Figura Hatsune Miku 1/7', 8500, 'Figura', 8, 'Figura de alta calidad de Hatsune Miku en pose icónica'),
('Camiseta World is Mine', 3500, 'Merch', 40, 'Camiseta oficial con el logo de World is Mine'),
('VOCALOID6 Editor', 18000, 'Software', 15, 'Editor oficial de VOCALOID6 con nuevas funciones AI');
