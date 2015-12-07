-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.12'

DECLARE @currentDbVersion       VARCHAR(11)
SET @currentDbVersion = dbo.GetCurrentDbVersionAsString()

DECLARE @errorMessage NVARCHAR(500);

IF dbo.CompareDbVersionWithCurrent(@newDbVersion) <> 1
BEGIN
    SET @errorMessage = 'Cannot install script ' + @newDbVersion + '. DB version ' + @currentDbVersion + ' expected.'
    RAISERROR(@errorMessage, 20, -1) WITH LOG
END
GO
-- End checking possibility of using

-- BEGIN CHANGES

INSERT INTO Brands
(
	-- Id -- this column value is auto-generated
	Name,
	IsDeleted
)
VALUES
(
	'Vortice',
	0
)

INSERT INTO Brands
(
	-- Id -- this column value is auto-generated
	Name,
	IsDeleted
)
VALUES
(
	'Германия',
	0
)

INSERT INTO Products
(
	-- Id -- this column value is auto-generated
	[Description],
	Price,
	Name,
	Brand_Id,
	CountryProducer_Id,
	IsDeleted
)
VALUES
(
	N'Центробежный вытяжной вентилятор для скрытой  установки Vortice Vort Quadro Super 100 I T HCS отличной вариант для работы в помещении с высокими требованиями к дизайну и качеству микроклимата. Поскольку вентилятор монтируется в стену, после установки видимой остается лишь лицевая часть аппарата. Vort Quadro Super I T HCS предназначен для выброса воздуха через сеть воздуховодов или стену. Модель подходит практически под любое помещение, даже с повышенной влажностью. 
 
Комплектация
Базовая модель состоит из вентилятора с двухскоростным двигателем, моющегося фильтра, обратного клапана и фланца для присоединения воздуховода, который в свою очередь позволяет организовывать вытяжку из соседнего помещения. Данная модель имеет дополнительно таймер на отключение работы и гидростат который включает вентилятор на вытяжку при относительной влажности помещения 65%, после понижения уровня влаги, вентилятор работает как модель с таймером отключения. ',
	250,
	N'ЦЕНТРОБЕЖНЫЙ ВЕНТИЛЯТОР VORTICE VORT QUADRO SUPER I T HCS',
	2,
	90,
	0
)

INSERT INTO Products
(
	-- Id -- this column value is auto-generated
	[Description],
	Price,
	Name,
	Brand_Id,
	CountryProducer_Id,
	IsDeleted
)
VALUES
(
	N'БЫТОВЫЕ ВЕНТИЛЯТОРЫ MAICO СЕРИИ ER ДЛЯ ВАННЫХ
Производитель специализированного оборудования Maico – традиционно очень востребованная компания в Европе, ее продукция считается качественной и надежной. Вентиляторы, выпускаемые с производства, используются в быту, в производстве, устанавливаются в офисах, мастерских и прочих помещениях. 
РЕКОМЕНДАЦИИ ПО ПРИМЕНЕНИЮ 
Представляем вашему вниманию вентилятор Maico ER 60 центробежного типа для вытяжки воздуха. Данное устройство предназначается для небольших помещений и устанавливается на стене или потолке в ванных комнатах, санузлах офисов, квартир, коттеджей и т.п. 
Модель выполнена в стандартной комплектации.',
	5250,
	N'БЫТОВОЙ ВЕНТИЛЯТОР ДЛЯ ВАННЫХ MAICO ER 60',
	2,
	60,
	0
)

INSERT INTO ProductProductCategories
(
	Product_Id,
	ProductCategory_Id
)
VALUES
(
	1,
	4
)

INSERT INTO ProductProductCategories
(
	Product_Id,
	ProductCategory_Id
)
VALUES
(
	2,
	4
)

-- END CHANGES

-- Start writing new version info 
GO
IF @@ERROR <> 0
BEGIN
    DECLARE @errorMessage VARCHAR(MAX)
    SET @errorMessage = ERROR_MESSAGE()
    RAISERROR(@errorMessage, 16, 1)
END
ELSE
BEGIN
    DECLARE @newDbVersion       varchar(11)
    SET @newDbVersion = '0.12'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, ''
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info