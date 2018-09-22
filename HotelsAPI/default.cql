CREATE TABLE Rooms (
	id int,
	Types map<text,int>,
	PRIMARY KEY (id)
);


insert into rooms (id,types) values (1,{'Standard':4518, 'Deluxe':4916});

insert into rooms (id,types) values (2,{'Standard':2526, 'Deluxe':2936, 'Premium':3213});

insert into rooms (id,types) values (3,{'Superior Queen':7000, 'Superior King':8000});

insert into rooms (id,types) values (4,{'Premier City View':14720});

insert into rooms (id,types) values (5,{'Deluxe':9651, 'Superior':10545, 'Executive':11438});