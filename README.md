# Project Discontinued.

### Started on: 12.03.2017
### Last updated: 13.09.2017
## README first!
- refactoring the Dorm placement application for the Faculty of Computer Science, this time in .NET Core with AngularJS and BlurAdmin theme
- write a clean, well documented code!

**LINKS OF INTEREST:**
  - Here you can find the flowchart and some other details, like db schema etc. It will change in time, but will always provide useful information regarding the application.
    - https://drive.google.com/folderview?id=0ByZw6A6tM3Stfm8xcEZmdy1fdFh2V1h4X1ZaN0xQSGR1dmp0OE9hMVpYeWFERHFOQkdRM1k&usp=sharing


Application is made out of 4 parts:
  1. Admin: creates session and adds details (DormsCategories -> Dorms -> Rooms -> Spots). Can change session state and view previous sessions.
  2. Student: creates application form and selects dorm/roommate preferences.
  3. Management: views the application forms and has to validate or invalidate it (with a message, allowing the student to resend the modified application).
  4. The sorting algorithm itself, which should be external (receives json/xml as input and outputs a sorted json/xml).

##### STEPS:
0. Start
  - [ ] Model the database
  - [X] Application structure 

1. Models 
  - [ ] Session
  - [ ] DormCategory
  - [ ] Dorm
  - [ ] Room
  - [ ] Spot
  - [ ] User

  * Also:
    - [ ] Form
    - [ ] DormPreference
    - [ ] RoommatePreference
    - [ ] Document
    - [ ] Message
    - [ ] Algorithm models (still designing)

2. Login
  - [ ] User controller
      - [ ] Login with central api
      - [ ] Split the application in 3 depending on user roles
  - [ ] Login view partial
  - [ ] Get data right depending on the account
  - [ ] Check syncronization with central api
  - [ ] Validate data coming from central api (cannot rely on their validations)


3. Admin
  - [ ] Session, dormCategories, dorm, room and spot controllers
    - [ ] Create new session with minimal data
    - [ ] Edit a session
    - [ ] Add status functionality. Open, close or archive. 
    - [ ] Add dormCategories, dorm rom and spot data
    - [ ] Validations
  - [ ] Session responsive view
    - [ ] Create new session page
    - [ ] Dynamic fields for dorm categories, dorms, rooms and spots
    - [ ] Add and modify rooms in bulk
    - [ ] List all the previous sessions (and their settings)
  - [ ] Business logic of admin's control over sessions
  - [ ] Good flow for subsessions 
  - [ ] Validations


4. Student
  - [ ] Form, document, dormPreference, roommatePreference and message controllers
  - [ ] Form responsive view
    - [ ] Two step form
    - [ ] Dynamic fields for dorm and roommate preferences
    - [ ] Dynamic search for roomate preference
  - [ ] Calculate score upon submission
  - [ ] Upload documents -- check document type before uploading
  - [ ] Messaging system between student and management
  - [ ] Validations!

5. Management
  - [ ] Management controller
  - [ ] Management view:
    - [ ] Responsive table with editable score 
    - [ ] Quckview of applications (bootstrap modal probably)
  - [ ] Check student's application. Validate or invalidate it(with proper message)
  - [ ] Add message for invalidation

6. Sorting algorithm:
  - [ ] ADD LATER

7. Design
  - [ ] Add menu
  - [ ] Add profile page
  - [ ] ...

Will add more to README as I progress.

To be added: a logic for seeing previous sessions and their settings/results.
