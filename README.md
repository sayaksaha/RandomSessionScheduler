# Problem Statement
Create a random schedule based on a input file that lists the training names and the duration in below format.


Session Name                                | Duration
--------------------------------------------|----------
Organising Parents for Academy Improvements | 60min
Teaching Innovations in the Pipeline        | 45min
Teacher Computer Hacks                      | 30min
Making Your Academy Beautiful               | 45min
Academy Tech Field Repair                   | 45min
Sync Hard                                   | 5min
Unusual Recruiting                          | 5min
Parent Teacher Conferences                  | 60min
Managing Your Dire Allowance                | 45min
Customer Care                               | 30min
AIMs – 'Managing Up'                        | 30min
Dealing with Problem Teachers               | 45min
Hiring the Right Cook                       | 60min
Government Policy Changes and Bridge        | 60min
Adjusting to Relocation                     | 45min
Public Works in Your Community              | 30min
Talking To Parents About Billing            | 30min
So They Say You're a Devil Worshipper       | 60min
Two-Streams or Not Two-Streams              | 30min
Piped Water                                 | 30min

The expected output is like:

Session Name                                | Duration
--------------------------------------------|----------
Academy Tech Field Repair                   | 45 min
Teacher Computer Hacks                      | 30 min
Unusual Recruiting                          | 5 min
Public Works in Your Community              | 30 min
Sync Hard                                   | 5 min
Adhoc Break                                 | 5 min
Lunch Break                                 | 1HR
Piped Water                                 | 30 min
Two-Streams or Not Two-Streams              | 30 min
So They Say You're a Devil Worshipper       | 60 min

# Constraints in brief

1. The schedule need to be random and the output should be unique in every run.
2. There are 2 sessions before/& after lunch. Each spans around 120 mins.
3. Fill the buffers (leftover time) in b/w any sessions with breaks (adhoc-break)

# How to execute the program ?
The execution begins from TrainingOrganizerMaster.cs. Pass the input filename in above format as command line argument.

# The Project Structure in brief:
- TrainingOrganizationMaster - The Master class which controls the execution.
- CustomException - Custom Exception class to read exception in details
- ExtractSessionDetailsToXML - The class reads the input file and converts it to a XML file named SessionData.xml. The file get stored at C:\temp\.
- Training - Primarily used to serialize the data. Raw format to XML.

