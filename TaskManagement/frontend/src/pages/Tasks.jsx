import { useTasks } from "../hooks/useTasks";
import TaskForm from "../components/TaskForm";

export default function Tasks() {
    const { data, isLoading, error, deleteTask, updateTask } = useTasks();

    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Error loading tasks</p>;

    return (
        <div>
            <h2>Tasks</h2>

            {data.map((task) => (
                <div key={task.id}
                    style={{
                        border: "1px solid #ccc",
                        borderRadius: "8px",
                        padding: "16px",
                        display: "grid",
                        gap: "10px",
                        backgroundColor: "#f9f9f9",
                    }}>
                    <span
                        style={{
                            textDecoration: task.completed ? "line-through" : "none",
                        }}
                    >
                        {task.title}
                    </span>
                    <span
                        style={{
                            textDecoration: task.completed ? "line-through" : "none",
                        }}
                    >
                        {task.description}
                    </span>
                    <button onClick={() => deleteTask(task.id)}>Delete</button>

                    <button
                        onClick={() =>
                            updateTask({ ...task, completed: !task.completed })
                        }
                    >
                        Toggle
                    </button>
                </div>
            ))}
            <TaskForm />
        </div>
    );
}

