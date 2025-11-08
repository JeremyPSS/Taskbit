import { useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Dashboard from './Components/Dashboard/Dashboard.tsx';
import Preferences from './Components/Preferences/Preferences.tsx';
import Login from './Components/Login/Login.tsx';
import './App.css';

function App() {
    const [token, setToken] = useState();
    if (!token) {
        return <Login setToken={setToken} />;
    }
    return (
        <div className="wrapper">
            <h1> Taskbit </h1>
            <BrowserRouter>
                <Routes>
                    <Route path="/dashboard" element={<Dashboard />} />
                    <Route path="/preferences" element={<Preferences/>} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;