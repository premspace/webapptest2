using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Constant
    {
        public const string SQL_CREATE_TABLE_PERSON = "CREATE TABLE PERSON(FIRSTNAME varchar(125), LASTNAME varchar(125), PHONENUMBER varchar(255), ADDRESS varchar(255))";
        public const string SQL_INSERT_TABLE_PERSON_1 = "INSERT INTO PERSON(FIRSTNAME, LASTNAME, PHONENUMBER, ADDRESS) VALUES('Chris', 'Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')";
        public const string SQL_INSERT_TABLE_PERSON_2 = "INSERT INTO PERSON (FIRSTNAME, LASTNAME, PHONENUMBER, ADDRESS) VALUES('Dave', 'Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')";
        public const string SQL_DROP_TABLE_PERSON = "DROP TABLE PERSON";
    }
}
