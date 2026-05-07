import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { AccountContextProvider } from './contexts/AccountContext'


createRoot(document.getElementById('root')!).render(
  <StrictMode>
  <AccountContextProvider>
    <App />
  </AccountContextProvider>
  </StrictMode>,
)
