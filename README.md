# TranslateGPT

An ASP.NET Core MVC web application that translates text into multiple languages using AI-powered translation services.

# Overview

TranslateGPT is a simple web-based translation application built with ASP.NET Core MVC. Users can enter text, select a target language, and receive translated content through an AI translation API.

The project was originally designed to integrate with the OpenAI API for translation tasks. However, due to API billing and quota requirements, the OpenAI integration could not be fully tested and completed.

# Features
  - Translate text into multiple languages
  - Clean and responsive user interface
  - ASP.NET Core MVC architecture
  - Language selection dropdown
  - API-based translation workflow
  - Easy to extend with other translation APIs

# Technologies Used

   - ASP.NET Core MVC
   - C#
   - HTML5
   - CSS3
   - Bootstrap
   - HttpClient
   - Newtonsoft.Json
   - OpenAI API (planned integration)

**Project Structure**
    
    TranslateGPT/
    │
    ├── Controllers/
    │   └── HomeController.cs
    │
    ├── Models/
    │   └── ErrorViewModel.cs
    │
    ├── DTOs/
    │   └── OpenAIResponse.cs
    │
    ├── Views/
    │   ├── Home/
    │   └── Shared/
    │
    ├── wwwroot/
    │
    ├── appsettings.json
    │
    └── Program.cs

**How It Works**
  - User enters text to translate.
  - User selects a target language.
  - Application sends the request to a translation API.
  - API returns translated text.
  - Result is displayed on the webpage.

**OpenAI Integration Status**

The project was initially developed using the OpenAI Chat Completion API.

**Example configuration:**

    {
      "OpenAI": {
      "ApiKey": "YOUR_API_KEY"
      }
    }

**During development, the following API limitation was encountered:**

    {
      "error": {
        "message": "You exceeded your current quota, please check your plan and billing details.",
        "code": "insufficient_quota"
      }
    }

As a result, the translation functionality remains incomplete until a valid OpenAI API plan is available.

# Future Improvements

  - Replace OpenAI API with LibreTranslate API
  - Add automatic language detection
  - Add translation history
  - Support speech-to-text translation
  - Add user authentication
  - Store translations in a database
  - Improve UI/UX design

# Learning Objectives

This project was created to learn:

  - ASP.NET Core MVC
  - REST API integration
  - JSON serialization/deserialization
  - Dependency Injection
  - HttpClient usage
  - AI service integration


# Project Status

**Status:** In Progress

The application structure and API integration logic have been implemented. However, translation functionality requires an active API service and billing-enabled account for completion.

***Author***

GitHub: [Tamima Naznin Chy](https://github.com/tamimachy/)

LinkedIn: [Tamima Naznin Chy](https://www.linkedin.com/in/tamimachy/)
