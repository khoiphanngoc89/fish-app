INSERT INTO Menu(Code, [Url], [Image], MenuType, IsActive)VALUES('Logo', '/', '\wwwroot\Upload\logo.png', 0, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('Home', 'Home', '/', 1, 0, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('Fish', 'Fish', '/Fish', 1, 1, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('Policy', 'Policy', '/Policy', 1, 1, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('About Us', 'AboutUs', '/AboutUs', 1, 0, 1);

INSERT INTO SubMenu(ParentId, Name, Code, [Url], IsActive)VALUES(3, 'Beta 1', 'Beta1', '/Fish/Beta1', 1);
INSERT INTO SubMenu(ParentId, Name, Code, [Url], IsActive)VALUES(3, 'Beta 2', 'Beta2', '/Fish/Beta2', 1);

INSERT INTO SubMenu(ParentId, Name, Code, [Url], IsActive)VALUES(4, 'Return Policy', 'Return', '/Policy/Return', 1);