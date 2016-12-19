CREATE TABLE [dbo].[Table] (
    [studentId]   INT         IDENTITY (1, 1) NOT NULL,
    [Nume]        NCHAR (100) NOT NULL,
    [Prenume]     NCHAR (100) NOT NULL,
    [Localitatea] NCHAR (100) NOT NULL,
    [Strada]      NCHAR (100) NOT NULL,
    [Bloc]        NCHAR (100) NOT NULL,
    [Apartament]  NCHAR (10)  NOT NULL,
    [Tara]        NCHAR (10)  NOT NULL,
    [Facultatea]  NCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([studentId] ASC)
);

