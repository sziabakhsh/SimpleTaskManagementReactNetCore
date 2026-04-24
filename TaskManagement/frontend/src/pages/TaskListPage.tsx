// 1
//export default function TaskListPage() {
//    console.log("🔥 PAGE RENDERED");

//    return <h2 style={{ color: "red" }}>TASK PAGE</h2>;
//}


// 2
//import { useEffect } from "react";

//export default function TaskListPage() {
//    useEffect(() => {
//        console.log("🔥 useEffect running");
//    }, []);

//    return (
//        <div>
//            <h2>TASK PAGE</h2>
//        </div>
//    );
//}



// 3
//import { useEffect } from "react";

//export default function TaskListPage() {
//    useEffect(() => {
//        console.log("🔥 calling API...");

//        fetch("https://localhost:7139/api/taskitem")
//            .then(res => {
//                console.log("STATUS:", res.status);
//                return res.json();
//            })
//            .then(data => {
//                console.log("DATA:", data);
//            })
//            .catch(err => {
//                console.log("ERROR:", err);
//            });
//    }, []);

//    return (
//        <div>
//            <h2>TASK PAGE</h2>
//        </div>
//    );
//}



import { useEffect, useState } from "react";

export default function TaskListPage() {
    const [tasks, setTasks] = useState<any[]>([]);

    useEffect(() => {
        fetch("https://localhost:7139/api/taskitem")
            .then(res => res.json())
            .then(data => {
                console.log("DATA:", data);
                setTasks(data);
            });
    }, []);

    return (
        <div>
            <h2>Tasks</h2>

            {tasks.map((task: any) => (
                <div key={task.id}>
                    <h4>{task.title}</h4>
                </div>
            ))}
        </div>
    );
}