# Product Requirements Document (PRD) – Daily Friend Trivia

## 1. Vision & Objectives
Create a lightweight web app where friends can log in, contribute personal trivia questions, and answer one new question each day to strengthen social bonds through playful interaction.

## 2. User Stories
- As a player, I want to log in easily so that I can access my group’s trivia game.  
- As a player, I want to submit trivia questions about myself so that my friends can learn fun facts about me.  
- As a player, I want to answer one trivia question per day so that the game feels fresh and consistent.  
- As a player, I want to see if my answer was correct so that I get immediate feedback.  
- As a player, I want to track my participation streak so that I stay motivated to return daily.  

## 3. Feature List
**MVP (under 1 hour build):**
- Basic login (shared code or simple username entry, no full auth needed)  
- Form to create and save trivia questions with answers  
- Daily trivia logic: one question shown per day to all players  
- Answer submission with correctness check  

**Stretch Goals (nice-to-have):**
- Leaderboard with points for correct answers  
- Notifications/reminders (email or push)  
- Categories/tags for questions (funny, serious, random)  
- Streak tracking and badges  

## 4. Success Metrics
- At least 3+ friends log in and play within the first week  
- 80% of players answer the daily question consistently for 7 days  
- Each player contributes at least 5 questions to the backlog  

## 5. Constraints or Assumptions
- MVP should be completable in under 1 hour using a lightweight stack (e.g., Flask + SQLite or Node/Express + JSON file storage)  
- Authentication can be minimal (shared group code or nickname entry)  
- Only one trivia group supported in MVP; multi-group support can come later  
- Deployment assumed to be on a free/low-cost hosting service (e.g., Vercel, Netlify, or Heroku free tier)  
