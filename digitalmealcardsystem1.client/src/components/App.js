/* eslint-disable no-unused-vars */
// src/components/App.js
import React from 'react';
import Header from './Header';
import StudentList from './StudentList';
import MealCard from './MealCard';
import Allowance from './Allowance';

function App() {
    return (
        <div className="App">
            <Header />
            <StudentList />
            {/* You can pass studentId as a prop to MealCard and Allowance components */}
            {/* <MealCard studentId={1} /> */}
            {/* <Allowance studentId={1} /> */}
        </div>
    );
}

export default App;
