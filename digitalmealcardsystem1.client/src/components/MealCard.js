/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
// src/components/MealCard.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const MealCard = ({ studentId }) => {
    const [meals, setMeals] = useState([]);

    useEffect(() => {
        axios.get(`http://your-backend-url/api/meals?studentId=${studentId}`)
            .then(response => setMeals(response.data))
            .catch(error => console.error('Error fetching meals:', error));
    }, [studentId]);

    return (
        <div>
            <h2>Meals</h2>
            <ul>
                {meals.map(meal => (
                    <li key={meal.MealID}>{meal.MealDate}</li>
                ))}
            </ul>
        </div>
    );
};

export default MealCard;
