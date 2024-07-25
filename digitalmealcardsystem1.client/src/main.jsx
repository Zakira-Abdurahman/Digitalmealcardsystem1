/* eslint-disable react/no-deprecated */

// src/main.jsx

import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'; // or './main.css' if that's the correct file
import App from './components/App';

ReactDOM.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>,
    document.getElementById('root')
);

