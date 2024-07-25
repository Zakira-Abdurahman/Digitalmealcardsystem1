/* eslint-disable react/prop-types */
// src/components/Allowance.js
// eslint-disable-next-line no-unused-vars
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Allowance = ({ studentId }) => {
    const [allowances, setAllowances] = useState([]);

    useEffect(() => {
        axios.get(`http://your-backend-url/api/allowances?studentId=${studentId}`)
            .then(response => setAllowances(response.data))
            .catch(error => console.error('Error fetching allowances:', error));
    }, [studentId]);

    return (
        <div>
            <h2>Allowances</h2>
            <ul>
                {allowances.map(allowance => (
                    <li key={allowance.AllowanceID}>{allowance.AllowanceDate}: ${allowance.Amount}</li>
                ))}
            </ul>
        </div>
    );
};

export default Allowance;
