import './App.css'
import {BrowserRouter as Router, Routes, Route}  from "react-router-dom"
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'

import Nav from './components/Nav'
import ProtectedRoute from './components/ProtectedRoute'
import Home from './components/Home'
import Tasks from './pages/Tasks'
import Login from './pages/Login'
import Register from './pages/Register'

  const client = new QueryClient({
      defaultOptions : {
        queries:{
          refetchOnWindowFocus:false
        },
        mutations:{

        }
      }
  });

function App() {
  return (
    <>
    <div className="App">
      <QueryClientProvider client={client}>
        <Router>
          <Nav />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={
                <Login />} />
            <Route path="/tasks" element={
              <ProtectedRoute>
                <Tasks />
              </ProtectedRoute>
            } />
            <Route path= "*"  element={<h2>404: Element not found</h2>}/>
          </Routes>
        </Router>
      </QueryClientProvider>
    </div>
    </>
  )
}

export default App
