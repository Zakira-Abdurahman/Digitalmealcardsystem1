/* eslint-disable no-unused-vars */

// src/components/StudentList.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const StudentList = () => {
    const [students, setStudents] = useState([]);

    useEffect(() => {
        axios.get('http://your-backend-url/api/students')
            .then(response => setStudents(response.data))
            .catch(error => console.error('Error fetching students:', error));
    }, []);

    return (
        <div>
            <h2>Students</h2>
            <ul>
                {students.map(student => (
                    <li key={student.StudentID}>{student.FullName}</li>
                ))}
            </ul>
        </div>
    );
};

export default StudentList;
