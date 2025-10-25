---
description: Instructions for GitHub Copilot when working with Friend Trivia - A Daily Social Trivia Game
applyTo: '**'
---

# Project Overview

Friend Trivia is a lightweight Blazor web application that enables friends to share and answer daily trivia questions about each other. The application focuses on simplicity, daily engagement, and social interaction through personal trivia.

## Project Goals

- Create an engaging daily trivia experience
- Keep the application lightweight and simple
- Foster social connections through personal questions
- Maintain consistent user engagement

## Technology Stack

- Blazor (.NET 9.0)
- ASP.NET Core
- Entity Framework (EF) Core
- Tailwind CSS
- DaisyUI (Tailwind CSS Component Library)

## Core Features

- Simple user authentication (username-based)
- Daily question presentation
- Question creation and management
- Answer verification and feedback
- Participation streak tracking

## Code Generation Guidelines

### Blazor Components

- Use Blazor component syntax with `.razor` files
- Follow component naming conventions: PascalCase for component names
- Include `@page` directives for routable components
- Use `@code` blocks for C# logic
- Implement `IDisposable` when needed for cleanup
- Create reusable components for trivia questions and answers
- Implement daily question rotation logic
- Use component parameters for question/answer data passing
- Build simple login/registration components
- Create question submission forms with answer validation

### C# Conventions

- Use C# 12 features where appropriate
- Follow async/await patterns for asynchronous operations
- Use dependency injection following ASP.NET Core patterns
- Implement proper exception handling
- Use nullable reference types
- Implement lightweight authentication using usernames
- Create services for managing daily questions and user progress
- Use DateTime handling for daily question rotation
- Implement streak tracking logic
- Store questions and user data efficiently

### Tailwind CSS

- Use Tailwind CSS utility classes for styling
- Follow mobile-first responsive design principles
- Utilize DaisyUI component classes where appropriate
- Prefer utility classes over custom CSS
- Use Tailwind's configuration for extending themes
- Keep UI lightweight and clean
- Implement responsive design for all screen sizes
- Use consistent spacing and layout patterns
- Ensure good readability for trivia questions

### DaisyUI Components

- Use DaisyUI component classes (btn, card, modal, etc.)
- Follow DaisyUI theming conventions
- Implement responsive designs using DaisyUI breakpoints
- Use DaisyUI color schemes consistently
- Use cards for displaying daily questions
- Implement modals for answer feedback
- Style forms using DaisyUI form components
- Use alerts for success/error messages
- Apply badges for streak tracking

### Best Practices

- Component organization: Place components in appropriate subdirectories
- State management: Use Blazor's built-in state management features
- Performance: Implement component inheritance correctly
- Accessibility: Ensure ARIA attributes are properly used
- Code organization: Follow clean architecture principles
- Question Management: Implement logic for one question per day
- User Experience: Provide immediate feedback on answers
- Data Persistence: Store user progress and streaks
- Security: Implement basic input validation
- Error Handling: Provide user-friendly error messages

### Models and Data Structure

- Question Model:

  - Question text
  - Answer
  - Author (user who created it)
  - Creation date
  - Tags/categories (for future use)

- User Model:
  - Username
  - Streak count
  - Questions created
  - Answer history
  - Last answer date

### File Structure

- Components go in the `Components` directory
  - Daily question component
  - Question submission form
  - Answer feedback component
  - Streak display component
- Pages go in `Components/Pages`
  - Home page (daily question)
  - Question creation page
  - User profile page
- Models go in the `Models` directory
- Shared layouts go in `Components/Layout`
- Static assets go in `wwwroot`
- Services go in the `Services` directory
  - Question management service
  - User service
  - Authentication service
