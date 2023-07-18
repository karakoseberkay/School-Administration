import { Demo } from '../../types/types';



export const DepartmentService = {

    
    getDepartments() {
        return fetch('http://localhost:5191/api/department')
            .then((res) => res.json())
            .then((d) => d as Demo.Department[]);
    },

    postDepartments(department:Demo.Department) {

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(department)
        };
       return fetch('http://localhost:5191/api/department', requestOptions)

    },
    updateDepartment(deparment:Demo.Department){

        return fetch('http://localhost:5191/api/department/'+ deparment.id, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(deparment)
          })

    },
    deleteDepartment(id:any){
        return fetch('http://localhost:5191/api/department/'+id, {
            method: 'DELETE'
          })
             .catch((err) => {
                console.log(err.message);
             });
    }

};
