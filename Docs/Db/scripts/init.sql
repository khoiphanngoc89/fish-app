INSERT INTO Menu(Code, [Url], [Image], MenuType, IsActive)VALUES('Logo', '/', 'https://firebasestorage.googleapis.com/v0/b/fish-d3e4f.appspot.com/o/Uploads%2Ffavicon.png?alt=media&token=f60eca1b-3c4a-406f-a1a8-a00f1c37dc6e', 0, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('Home', 'Home', '/', 1, 0, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('Fish', 'Fish', '/Fish', 1, 1, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('Policy', 'Policy', '/Policy', 1, 1, 1);
INSERT INTO Menu(Name, Code, [Url], MenuType, HasSub, IsActive)VALUES('About Us', 'AboutUs', '/AboutUs', 1, 0, 1);

INSERT INTO SubMenu(ParentId, Name, Code, [Url], IsActive)VALUES(3, 'Beta 1', 'Beta1', '/Fish/Beta1', 1);
INSERT INTO SubMenu(ParentId, Name, Code, [Url], IsActive)VALUES(3, 'Beta 2', 'Beta2', '/Fish/Beta2', 1);
INSERT INTO SubMenu(ParentId, Name, Code, [Url], IsActive)VALUES(4, 'Return Policy', 'Return', '/Policy/Return', 1);

INSERT INTO Member(FirstName, LastName, Address, Phone, Email, PIN, City, Country)VALUES('admin', 'admin', '5 Test', '6555455344', 'admin@gmail.com', '1234', 'SaiGon', 'VietNam')