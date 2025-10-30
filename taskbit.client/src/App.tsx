import './App.css';
import './Components/Dashboard/Dashboard.tsx';
import Dashboard from './Components/Dashboard/Dashboard.tsx';
import './Components/Preferences/Preferences.tsx';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Preferences from './Components/Preferences/Preferences.tsx';

function App() {
    return (
        <div className="wrapper">
            <h1> Taskbit </h1>
            <BrowserRouter>
                <Routes>
                    <Route path="/dashboard" element={<div>Dashboard Component</div>} />
                    <Dashboard />
                    <Route path="/preferences" element={<div>Preferences Component</div>} />
                    <Preferences />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;