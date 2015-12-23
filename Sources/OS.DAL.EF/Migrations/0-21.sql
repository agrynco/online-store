-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.21'

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

CREATE TABLE [dbo].[ContactInfos] (
    [Id] [int] NOT NULL IDENTITY,
    [Content] [nvarchar](max),
    [IsDeleted] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.ContactInfos] PRIMARY KEY ([Id])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201512231945452_migration', N'OS.DAL.EF.Migrations.Configuration',  0x1F8B0800000000000400ED5D5B6FE4B6157E2FD0FF3098A7A4D8787CC92EB60B3B81776CA76ED61778BC41FB349035F458882E1349B3B151F497F5A13FA97FA1A44449BCDF7499998D1160E311C9C3C3C38F87E4E121CFFFFEF3DFE31F9FA370F405A45990C427E383BDFDF108C47EB208E2E5C9789D3F7EF77EFCE30F7FFED3F1F9227A1EFD52E53B42F960C9383B193FE5F9EAC36492F94F20F2B2BD28F0D3244B1EF33D3F8926DE22991CEEEFFF757270300190C418D21A8D8EEFD6711E44A0F8017F4E93D807AB7CED8557C9028419FE0E536605D5D1B517816CE5F9E0647C33DB3B3BFDB4777E311E9D868107199881F0713CF2E238C9BD1CB2F7E1730666799AC4CBD90A7EF0C2FB971580F91EBD300398ED0F4D76D316EC1FA2164C9A8215297F9DE5496449F0E0088B64C2167712ECB8161914DA39146EFE825A5D08EE64FC31F5E2C578C4D6F4611AA6285721D48FEB2C884196ED9DC12C41BC57947933E253DED430806841FFBD194DD761BE4EC1490CD679EA856F46B7EB8730F07F062FF7C9AF203E89D761487208798469D407F8E9364D5620CD5FEEC023E6FB12323DA1CB4DD8827531A24CD9A8CB383F3A1C8FAE61E5DE43086A00100298E5490A7E023148BD1C2C6EBD3C07698C688042845CED4C5DE8DFAA3688383866C6A32BEFF9138897F9D3C9F8F02D1C2517C13358545F30079FE3000E3158284FD740C0A1BAD6CBEC0C8400F25B55FD314942E0C51A42C79306174AB4C0D1987B7E7E193F269698214ABE224759179214CCA9000FFCD3083C9BC70A6C07FE1F4A70800C4DE0153926C841D5E9AB3522D5968C23C620A16BEF4BB02CA4221B1E77202CD2B3A76055CEF41562E63C72323860D224BA4BC2868428DBFCDE4B97000DBE449F7796AC53DF9EF57228C8D947E9864D90659535439A5FD414DB91EE36BC5FC7B466202E9A75040192F3781D590FC79D5A94188C247A74F4A310AA9161A210AA51D76614B94F94AF33A4F368425F5E4794C588EA628E928C2CED9CE638BAD6719EBE588FACA2D4EBA852D6751E2FC3207BD28C859E86C2EC4651E71153655945BB1A6F9F9218508AA4AF1DDAFDEFC9F4C94B334D65873D34F2FE2905C0A4F23E24BC1920F5BC1DBE0842DB791D1579553DCABA9088B473F0DB0EC6E299977B353282D8435389C980DF82895C388F23C109665972FE9664E1E66D59BE56F3356CD562EDE750D9E6B6A646B26897C367F4D1CB00B1762C46B4A67BAF607D3D2914DCCC291C37CBC47A65C3947E5533EA39DF4B45D6308DCA00999F06ABF2E046AA9E0EF60FBFEF403F75A404B76023F214840B0CCB40B20961C03BE7CA344A4C93955366BAFC22A5A66A4E899CBE5BC19AFB4C5B6DDC8A929EB237E64AD6E77A6EE71A066D35A39B467CD5841D28B56EF63FB769E0D74AED0CF841E4C159F836857F619F84F7E3D1CCF75043EDCF268A53ECB6071C5F8DDAC57E008AE18D73F023BB489029529C6AAB36CD2600739523E3AE8566C7B6A1921248D57CB27905CCD259E41C33F9AC2724B42C564BB5CAC23359A64879C3C9AD16FE95224294551AFCAAF67939CD56D720DFAB0AEE95242F5248EEF724FD758FA4F866645CAE51FA87A64AFFE8E0E1F1E8FDDB77DEE2E8DDF7E0E8EDF01380688179F8BE0F1DA4D57CEF3AA9558AE3CF19EC1D218CC9FE9EE36C0D94F9540ECE822C9D401A91EA1ED615D5ED8736E29487B7302B6A90CB48A8AA187A3454FCF65BAF31E24E572BD87905B490442C57C24CE99D5E110F0781732897B0038D6850CB34891F83347258FF71BBD32C830A61F1372F7BEA7D393F03FE3A85389DE55EB4EA7FF3808E69AED7D10382FF707575D635F7BF27179E0F376BE7312AD59ADEA7C4FF3559E7E7F1E20CAE793FE77EBDB1823FEF83C89C4027EC9CFA3ED4261710CC60512C69DBEDC3909EDAF48A641A7A41245E92301A755E656D9625E21CDCD24492CD7613F0295906B119AB555639AB650E2DAB389B2DAB889819A738A79CD1228396CF3257670BBEA287BA5FF11564B77FC9B7EDE6AC4DAD178BEE2B0FDC7A9E9B8A9A7EF1C275D755398D864209743F1A0AB2DB3F1A0A36E1E72FC102AD4A0CF641556648DE28BF788BA51F730C67430F07AA9943573E8C0E900F9775C47B8196CE8897D945E82D9BFB692E5EA18852A7A7E09F63D851E10B1412A9A469095F01B416AEC67FE42D21F3850E82C2E4C5520A402F94C64BB30BC154D4362B9CBFDF9EFF24930D9BF7F6BAC97A6822C6D32C4BFCA090082D49A1EB265D33DC288C2CBCA339975A3882A0C402B4B682A8476D63B5D74D5C9E628C4EFDF26EE4D4CB7C6FC18F57D8B6850B73F53923C71CE5F142F3F917AE7AA85D013AC40D3CB4F1CE60EF0771CEABE220F68395179A0B8D2161B87E42F2A82B6353CEC00AC468CE33978E0917C46D209E99BA4EA6D374623B9E10F03442ADD4E958030EBD07B2D0217C58046BDD9E3788629D008743B24E4A166846E536866899FB9D0C245A5F3CC62D4D0B073D6927DCEDEFED7113BCB150740E31B21618FBF8342DE19CE774CDB0AA50203A4D851D8D5743490C305E0D4564C249E37CB791A14AFB3F6820C13A437000B0199962170A822676C9E8719A6A83429AEFE13047F78149BDB52BD0460166AEE9849E2D9D40AD4B25E62202C64F46CBAECC69A61B61485C6DA819115F2BEB7E1AACDC70745CB23E39DAA69B4D6EAC330F4F17FBE677850181DB868C45950F47C326ED4934C85A5EE1392260ACF107E965312097D200BA582E0993CAC5EE1F03E963C9619DACCF7527774DBF735E19836052736428C1253EB6EA05986A890D004EB5484C1890BA326D02A0F888D61400EC79EDB6019439289600149F240D02505A621B00282D929D036879326FDAFFCC31FDB6C193F60F187E5A578A6B03D8A4E4B165D02C8FDC90BD0A96A8CF5198C3E0B387C2A0F52CBA300479C54749193EE563618248CD404EEE24B3F1A839EBA3B7EADCAA9B2E3E6D5EC9131121928D48B176723145D6A267465841CD94848629436ED0062C90D0C19B330D0D640115952F2DA99AC2F49E58CC08B76F36A3A920A525819DA1B8F2F4A6484384D5682A828DD6D310C51EF91C214EBB5B3057F9D329B9C34B5A0BB295EF9B922C5E8830640985C4E15EFC700E51C2E0F52A5677DA1DD7D68D268733A78FED4E59799A74FBD829979690B9F4A4A78072099A1D1C5A9DCAC925296CAE15EDC1242A7D048297A4D18195D59115D13AAC801522D31D52F52E2AED656D5E6456C7594E075A44AB05D390429CA607583615B80BB5BA5A2A15A1E8ECC5E0F485E7DE482ACC790B41A55ADD75D6702300490F064C8F065CE5B0394070F76515C2511D19581D1A388B49724C40E9A47A95DA998CAA5BBA72D1880E104C8E105C05C19C18E814BC43DB45573BF9F6EB4E124CCF128806E0D5AF42080AD33F4147B0A26E2D14D9E5125E3026966D1BDB36D130DC190A0169ECD01221558DE95C4AD5DA5E2F259179D5C6C0DA4A4A8C315422A5AA319D4B0963542F248189CFC2C8D74A44B441AEA3C156B96BD7B6A33AED7852461EC11F8E2753718892E32B6FB50AE22511B2047F19CDCA7825D3EF66F6113DA292C6C4A7A4CD5ABAEA9AF224F59680492D1FC2BD08D22C47EFDA3D78C8877ABA88B86C524B99640F5D554B19C3F89EAC76D35576F47759A40EE1B2275CF23532843C2D2364942C2E00B16B34BEDC08058CF1422F155C369A26E13A8AE5C65179E9F2CA2159BEFC624E8178CA8562A3F9CCD33A9E3042E00CA99C88397337DD6146DD491927DD3A953460DA77ADB2743F1D5C5B3449121233E757D4CD7A3B89696FABCD05869DAE23D26BDF577EC20204C85C88B53425F4EC68ED1EA65A02C91D3DC3416601D89EE58F1B5514FE70334A373AA69D721956ABBC42C40A2295E5C4151FE519A00B362425FBC105F5883E49864AB0E863F4303EC50EFA605E9E78E69EA4427C36A7453F644F92A3532C2832EFD3533499B4D791251C59A54DCE66545D66E8EF9BC76F9AE185887CEB30B8F8B7B395526D35B29A37E2491ACD57734AE523F02495F2CB76E3C35857527EDDF67D4A16E780D557E7564FACD3D22CBF6DCD50E38F4A5A7550ED47E2DC47720AFDF45273858B9A4BA417BBE494A8F787A9914826BCAA7C150E5BC2CF1D7643C1AD6B90E087A829EC969FCC69D477CC482AD28B67723A7F28C0CA4E154CD04A79BAD943565D7CD3E6E40DF5077FA2D2AE6F6AA741F7FE91939049B9F23F26E52CF3499653A9AE28915464D79636D65FB2C36F933E62FD31EDBB484BA1A79D74F9102BB5872E3F59D298366F7972C488349B6510F9DC2ABD142253CC29326FAA92249924CB9D7FF5722AB7F7AF129CE849242ACE61655F60DE4A656C0C4CAA3965C1ABA9246941B2036D01CF6C9A3955C1C3AA246141B239EDE6955556776EF13C257572B19DA84AFFF176339584463F8AB09B898E78AA92B25A379F2D69E1C7283962F8FB568248EA03640BA2F2B6403B104968C8F50CF5B623AD66940F52CA69DE920F36D2FB22C58395727A7650ED1B10B457106F3615FACC8B7A5E9AD9C41E8A5C9E04A64C851B3C2F2823AD222028BE9F4730E4CEABF4A6A2B306543206AB5E04C5DDD4CB0C3DD059BF19692D01D65BCC1A3A22AF6F859D85CA2733B6AAED79826E91FB893BF64845B003C8C81DCFDBF156DF73B0E3B1BB0E67DDD995BDCE663634A6A9E429F65077561734B52E3B5EEC9ABF65BA42D7FCCE7053B9F8ABE052E5B13A8D5174017D17607B74027DB960AB10216FAD1E099C9F319BA55EEBE02FF5EFDACF18FBF852CEC78540902B7121880CFB1BB34EBF65161452B15CB49D8C672F590EA23D94616FF65B380D03E43D5567B8F2E2E0116479F9E4F1F870FFE0703C3A0D032F2BDDC2B13BF307F61EBD917FF3C111F26F068B68C216B7F7924654B26C41051CE25FA6173DE9374058830089541BB8A0453CB6F88B97FA4F9E28EED365BC00CF27E37F15A53E8C3EFF5CDE7643BFDE408C7F8E83DFD6F0FB7DBA06A37F33F153F6DB07AA7C08F2AE625C49BD8177B60B6BBF62BA17BF89BCE76F496226611FFA963C50BD5BBBE31D50B9F51235E9C6D1E53FE654E137A39B14EACB0FA37D348ADCD87066A165F50340E7ABC1CB02501574A2B3B75CE77E6D43FE0FD78502B7D69DED3ECA39D661F183A54190D1AC825C7A1339DE62DE6C1983651142354C1DD907DC69DC783B586CD05EBC8E4D2589E896A2F6D114199F60571E29329DF74A5B18F784DF1EB5116FF7DE5955D438142B6783B7B683AB74312E6942920F41ECA52F43ED09A48B53D654EEB450A589C816AD2D42CF29CDE33B8BB4C66FD642EA504BDCDEDD9C7D9EDE4F4FEFCF7FBAB9FBE7FCF6F4EEFCFA7E7E7936BF3EBD3AAFC57F205221969825FD2C15C3E160FFF07B5BDACE4AD2B0F9875A3BC8DBAD52A1C2E3809DC5B602394E3A0FFBE9969416C00F222F44F64CF85711DF6D7CF01E36C2F7103DFB6545EDBF6BA7FE70B156BB74F76150E2C5C8E23708D245730C7FC4623BC1B0147A985DE42EC2430C3FB14245A12A0741126A34FAABF8AC05D2BBAEB49DDAEDD74CEED20788F9AC628F5E7D37D13145CDA50AA15B16A5E1DAB287AB56387053166DC18D71CF2ABD85776A40616F63E536E09DED44C67A1DBB6B57DAD7B8833996F134EE62D6263D8DBBA5D78908799762775A021F62BC5A813FF300E966BBC6B2BEC3EEAC099C85DD2DA58D9BB0F5A20597DCE05423F0DBDDD925F676CD4D841F7107039D8F766F41AE45447B0764EC5830F8CE66C75B3ED67B67B437096DDB0D7B07B629A59B9534BBC21B528F0DB24ABB2D5953B2D5BE57D4082746080A160C59F7B22888DF5033878130BAE98D5EE06066D22E9F7A686B5593C61C7789372E8A993C6C3071EE62C28602870F18195CFD10185FABE2C9BD5D8969BF1D81EBB7056BC63DBF51BC55BE651BC19C6DD4F9D63DAC09355B065822289AC5AE6F839281C1227EE74A0E0FFD1DACE102529B052E914715B1091D6D1693B82A5DBA9A9B53EF0842CA157B3FF81135DCA45AF9D34A8386341739D837BD8AC3BE10FDD87F407B0E536EC1C29DF0237BD2BC2FD41855257D826850A0686E23BA755BBFC031D07683AAA50181E5A20895B68A0D414D7499AC9BF9EC8F05BD0DCC882D20A8B90D3C241455B1ABA875380E644A2DBEF1379785D480939EFC01E68D4E7B66979807C0822E589524C49430F2B428EA744F9A880FFB2AE0A7E748D89A17FE3AC797C1AB75A61E240381CB24E0973CB2D216045F17C4EF95E00CA70E11727D68ACC91E9EB2F06CDA04D8446F26ED0CD870546709D870EAD70836D903555B0E36C16BA43B83B54DCD9F1B469AF114BA51A091E7B873D4470DC1F9459A44F3C2A87E9FCCC98C72241A99BC0D56F0E4D330CCCE0FA718EC0B9C50636CD2EE68A3270927605CE180FB394DDF5B6CBECCB671B620D85D8393390806B6339DD3AFF7D4BB4B36BC26DB93F89D26D2085BC52EE5EDE1E53B3D27E3C543023BBB746E90C422672993AFA4F0F4A954512D54CC4793BAD8F34061956C2659CDEC99B82103F25A955519D357B74CDB24D3B660FB8EA01E9C22AE4316699CADA09C7838EAE567116971106F962C6778E46AE072882AA33399B4A7D6A4B20A9515E9E9D34616AE123A5954D369B6BA06B93810B1ACB2660528ADB0C922AF541E0199AD985B0D73F57239D4D5DAB515EFE2958DC579D4D54AE286ABEAC69B3A65DD388FBA6E49346E09608D078CCDB8711E3ED5C241CA44F5DCA0A26E9C85A950186F5CE56527883A6EEC94C798CFA969810A0CCAAF11D4EE2F3C092A99DD015A0760D7B985C98562E649266AA0AC65A2266D5C40D2279579C118B93B75DB20C15E8F285F7E682D029D7F8E4014562E3DA2AD06AB9E84D1C454C210BAF098D37217137642910B45E4A542B14EADCE8920F306CD1535B1C3A6F16E138A666A5F7C76635FB831D583A6BFFEE60FF8CD84227E5AB6BFA1B05921B1AF4C2B44A43AA566D427B567A1C2E86E6EB0084E5805ADD59DC30AADB7E4D29C8F1AA66AB26C812F8E6DD55E0892934081204CCE0CD5C675A2255C9AA148A87D80248A4AF742A916EE7AA148E381F429146A8322890AD2BD50F0BE512F135940B83E4532C4D0713C01906BD4566709F62B4C95E55830E588776FEE338D561C42B379A7AB91EE1ACB3DD75EA71D4FCA2D31FE007F72CFB21F4FEEE05C1844E5CDB3E3339005CB86047A6B3E063E6560AEF320036C65EB6638AAB2DCD237E3AE40EE2DBCDC3B4DF3E0D12B9612E8327F102FC7A3E282347A52E2012C2EE39B75BE5AE7B0C9207A08A9891AD9CB55F51F4F389E8F6F8AB79BB22E9A00D90CD0230837F1C735DCAED47C5F08EEF5494820433CBE3A8FFA324757E8972F35A5EB24362484C5579F1FDC8368154262D94D3CF3BE0017DEA08AFA04969E8F5656F8AAB58C88BE2368B11F9F05DE32F5A20CD368CAC39F10C38BE8F987FF03185D1C03E3F10000 , N'6.1.3-40302')

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
    SET @newDbVersion = '0.21'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, ''
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version infon