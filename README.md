# 🎫 EventHub

A full-stack event management platform that connects **participants**, **event organizers**, and **admins** in one seamless experience. Built with React on the frontend and ASP.NET Core (.NET 8) on the backend using Clean Architecture.

---

## 🚀 Features

### 👤 Participants
- Browse and search public events
- Add events to a **watchlist** (favorites)
- Add tickets to a **cart** and checkout
- View purchased **tickets with QR codes**
- Receive **real-time notifications** when new events are approved

### 🎙️ Event Organizers
- Create, edit, and delete events (with image attachments)
- Manage event submissions pending admin approval
- View an **organizer dashboard** with event stats
- Track analytics for their events

### 🛡️ Admins
- Full **user management** (view, approve, reject organizer accounts)
- **Event moderation** (approve or reject submitted events)
- Manage **roles and permissions**
- Admin dashboard with platform-wide overview

---

## 🛠️ Tech Stack

### Frontend
| Technology | Purpose |
|---|---|
| **React 18** | UI framework |
| **React Router v6** | Client-side routing & protected routes |
| **Bootstrap 5** + Bootstrap Icons | Styling and responsive layout |
| **Axios** | HTTP client for API calls |
| **Context API** | Global state management (auth, cart, events) |
| **SignalR** (`@microsoft/signalr`) | Real-time event approval notifications |
| **react-hot-toast** | Toast notifications |
| **Font Awesome** | Icon library |
| **jwt-decode** | JWT token parsing on the client |

### Backend
| Technology | Purpose |
|---|---|
| **ASP.NET Core (.NET 8)** | REST API |
| **Clean Architecture** | Layered project structure (Core, Application, Infrastructure, Presentation) |
| **Entity Framework Core** | ORM & database access |
| **JWT + Refresh Tokens** | Authentication & session management |
| **ASP.NET Core Identity** | Role-based authorization |
| **AutoMapper** | DTO mapping |
| **SignalR Hub** | Real-time notifications |
| **AOP / Logging** | Cross-cutting concerns |

---

## 📁 Project Structure

```
EventHub/
├── Frontend/
│   ├── public/
│   │   └── index.html
│   └── src/
│       ├── api/
│       │   └── api.js               # Axios instance & interceptors
│       ├── components/
│       │   ├── AuthModal.jsx        # Login / Register modal
│       │   ├── EventCard.jsx        # Reusable event card
│       │   ├── EventDetailModal.jsx # Event detail popup
│       │   ├── Navbar.jsx           # Top navigation bar
│       │   └── UI.jsx               # Shared UI components
│       ├── context/
│       │   └── AppContext.js        # Global state (auth, cart, events, notifications)
│       ├── pages/
│       │   ├── admin/
│       │   │   ├── AdminDashboardPage.jsx
│       │   │   ├── AdminEventsPage.jsx
│       │   │   ├── AdminRolesPage.jsx
│       │   │   └── AdminUsersPage.jsx
│       │   ├── organizer/
│       │   │   ├── OrgDashboardPage.jsx
│       │   │   ├── MyEventsPage.jsx
│       │   │   ├── CreateEventPage.jsx
│       │   │   └── AnalyticsPage.jsx
│       │   ├── participant/
│       │   │   ├── EventsPage.jsx
│       │   │   ├── MyTicketsPage.jsx
│       │   │   ├── WatchlistPage.jsx
│       │   │   └── CartPage.jsx
│       │   └── ProfilePage.jsx
│       ├── hooks/
│       │   └── useEventNotifications.js
│       ├── data/
│       │   └── mockData.js
│       ├── App.jsx                  # Routes & protected route wrapper
│       └── index.js
│
└── Backend/
    ├── Core/                        # Domain models, enums, interfaces
    ├── Application/                 # DTOs, service interfaces, mapping profiles
    ├── Infrastructure/              # EF Core, repositories, external services
    └── IAProject/                   # ASP.NET Core entry point (controllers, hubs)
```

---

## ⚙️ Getting Started

### Prerequisites
- **Node.js** v18+
- **.NET SDK** 8.0+
- **SQL Server** (or update the connection string for your DB)

---

### Frontend Setup

```bash
cd EventHub/Frontend
npm install
npm start
```

The app will run on `http://localhost:3000` by default.

---

### Backend Setup

```bash
cd EventHub/Backend/IAProject
dotnet restore
dotnet ef database update     # apply migrations
dotnet run
```

The API will run on `http://localhost:5000` by default.

> **Note:** Update the connection string and JWT settings in `appsettings.json` before running.

---

## 🔐 Authentication & Roles

Authentication uses **JWT access tokens** with **refresh token** rotation.

| Role | Access |
|---|---|
| `participant` | Browse events, cart, tickets, watchlist |
| `EventOrganizer` | Create & manage own events, organizer dashboard |
| `Admin` | Full platform control — users, events, roles |

On login, the JWT is decoded on the frontend using `jwt-decode` to extract the user's role and permissions, which are then used to enforce **client-side route protection**.

---

## 🔔 Real-Time Notifications

EventHub uses **ASP.NET Core SignalR** to push live notifications to connected clients. When an admin approves an event, all logged-in participants receive:
- A **toast notification** on screen
- A new entry in the **notification bell** in the navbar

---

## 📡 API Overview

The frontend communicates with the backend through a centralized Axios instance (`src/api/api.js`) that automatically attaches the JWT token from `localStorage` to every request.

Key endpoint groups:

| Endpoint group | Description |
|---|---|
| `/Auth/login` `/Auth/register` | Authentication |
| `/Events` | CRUD for events |
| `/Events/GetCartEvents` | Cart management |
| `/Tickets/ResrvationTicket` | Ticket booking |
| `/Users/GetFavorites` | Watchlist |
| `/hubs/events` | SignalR hub |

---

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m 'Add your feature'`
4. Push to the branch: `git push origin feature/your-feature`
5. Open a Pull Request

---

## 📄 License

This project is for educational purposes.

---

> Built with ❤️ using React + ASP.NET Core · 🎫 EventHub 2026
