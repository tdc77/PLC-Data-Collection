# PLC-Data-Collection
Creating PLC data collection Programs

This is a program that will connect to an Allen Bradley Logix 5000 PLC and pull data from tags requested from it and store data in an excel sheet
by date AND shift.  In this case it only had 2 shifts but you could add another.  This program will email you a copy of the excel sheet ( as long as you are connected to same network ) at a given time ( set inside code of program ) or you can uncheck the send email checkbox to not send any emails. The scaled down version has the row colors commented out and does not track downtime. For the scaled down version you will need to make a STRING[10] array in PLC and move your data to the array to read. Also in the scaled down version the Automode and read ready are forced to true so it will automatically read the first time, but after that the data in the secondtb must be changed in order to read the next row of data.


PLEASE NOTE:
I AM NOT A PROFESSIONAL C# PROGRAMMER!! I know a little of this and a little of that, I am making one for python as well but thats still in the works.
Im a controls engineer by trade and like to dabble in programming on the side.  I wish the program was a bit more modular but one step at a time!

