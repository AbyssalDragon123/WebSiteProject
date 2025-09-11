--------------------------------------------------------------------------------
-- 0) (Opcional) Limpieza previa si ya existen
--------------------------------------------------------------------------------
-- DROP USER CIBERZONE CASCADE;
-- DROP TABLESPACE CIBERZONE_TBS INCLUDING CONTENTS AND DATAFILES;

--------------------------------------------------------------------------------
-- 1) TABLESPACE (ejecutar como SYS o SYSTEM)
--------------------------------------------------------------------------------
CREATE TABLESPACE CIBERZONE_TBS
  DATAFILE 'ciberzone_tbs01.dbf'
  SIZE 100M AUTOEXTEND ON NEXT 50M MAXSIZE UNLIMITED
  EXTENT MANAGEMENT LOCAL
  SEGMENT SPACE MANAGEMENT AUTO;

--------------------------------------------------------------------------------
-- 2) USUARIO / ESQUEMA (ejecutar como SYS o SYSTEM)
--------------------------------------------------------------------------------
CREATE USER CIBERZONE IDENTIFIED BY "Ciberzone#2025"
  DEFAULT TABLESPACE CIBERZONE_TBS
  QUOTA UNLIMITED ON CIBERZONE_TBS;

GRANT CREATE SESSION, CREATE TABLE, CREATE SEQUENCE, CREATE VIEW,
      CREATE PROCEDURE, CREATE TRIGGER TO CIBERZONE;

-- (Opcional para desarrollo)
GRANT UNLIMITED TABLESPACE TO CIBERZONE;
