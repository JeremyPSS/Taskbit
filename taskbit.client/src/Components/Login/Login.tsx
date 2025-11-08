import './login.css';
import PropTypes from 'prop-types'; // ES6
import { useState } from 'react';

/**
 * The function will take credentials as an argument, then it will call the fetch method using the POST option:
 * @param credentials
 * @returns
 */
async function LoginUser(credentials) {
    return fetch('http://localhost:8080/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    })
    .then(data => data.json())
}

function Login({ setToken }){

    const [username, setUsername] = useState<string>();
    const [password, setPassword] = useState<string>();

    const handleSubmit = async e => {
        e.preventDefault();
        const token = await LoginUser({ username, password });
        setToken(token);
    }

    return (
        <div className="login-wrapper">
            <h2>Please Log In</h2>
            <form onSubmit = { handleSubmit }>
                <label>
                    <p>Username</p>
                    <input type="test" onChange = {e => setUsername(e.target.value)} />
                </label>
                <label>
                    <p>Password</p>
                    <input type="password" onChange={e => setPassword(e.target.value)} />
                </label>
                <div>
                    <button type="submit">Login</button>
                </div>
            </form>
        </div>
    );
};

Login.propTypes = {
    setToken: PropTypes.func.isRequired
}

export default Login;