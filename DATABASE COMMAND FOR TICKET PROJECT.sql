Create Table Ticket (Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                     UserId NVARCHAR (450) NOT NULL FOREIGN KEY REFERENCES AspNetUSers(Id),
					 Ticket NVARCHAR (MAX) NOT NULL,
					 PicturePath NVARCHAR(MAX) NULL,
					 Approved BIT NOT NULL);

Create Table TicketDeveloper (DeveloperId NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
                              TicketId INT NOT NULL FOREIGN KEY REFERENCES Ticket(Id),
							  PRIMARY KEY (DeveloperId,TicketId));

Create Table Comments (Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
					   Comment NVARCHAR(MAX) NOT NULL,
					   UserId NVARCHAR(450) FOREIGN KEY REFERENCES AspNetUsers(Id));

Create Table TicketComments (TicketId INT NOT NULL FOREIGN KEY REFERENCES Ticket(Id),
                             CommentId INT NOT NULL FOREIGN KEY REFERENCES Comments(Id)
							 PRIMARY KEY(TicketId,CommentId));

Create Table StatusName (Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
                         Name NVARCHAR (MAX) NOT NULL);

Create Table TicketStatus (Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
                           TicketId INT NOT NULL FOREIGN KEY REFERENCES Ticket(Id),
                           StatusId INT NOT NULL FOREIGN KEY REFERENCES StatusName(Id));

Create Table Priority (Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
                         Name NVARCHAR (MAX) NOT NULL);

Create Table TicketPriority (TicketId INT NOT NULL FOREIGN KEY REFERENCES Ticket(Id),
                             PriorityId INT NOT NULL FOREIGN KEY REFERENCES Priority(Id),
							 PRIMARY KEY(TicketId,PriorityId));

Create Table ResolvedTickets (TicketId INT NOT NULL FOREIGN KEY REFERENCES Ticket(Id),
                              DeveloperId NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
							  PRIMARY KEY (DeveloperId,TicketId));

