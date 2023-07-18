import { Demo } from '../../types/types';

export const StudentService = {

    getStudents() {
        return fetch('http://localhost:5191/api/Student')
            .then((res) => res.json())
            .then((d) => d as Demo.Student[]);
    },

    deleteStudent(id:any){
        return fetch('http://localhost:5191/api/student/'+id, {
            method: 'DELETE'
          })
             .catch((err) => {
                console.log(err.message);
             });
    },

    updateStudent(student:Demo.Student){

        return fetch('http://localhost:5191/api/student/'+student.id, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(student)
          });

    },

    postStudent(student:Demo.Student) {

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(student)
        };
       return fetch('http://localhost:5191/api/student', requestOptions)

    },
};
