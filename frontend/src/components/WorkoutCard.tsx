import React from 'react';

// Định nghĩa giấy tờ tùy thân cho các thuộc tính (Props)
interface WorkoutCardProps {
    planName: string;
    animeStyle: string;
    days: number;
}

const WorkoutCard: React.FC<WorkoutCardProps> = ({ planName, animeStyle, days }) => {
    return (
        <div style={{ border: '1px solid #ddd', borderRadius: '8px', padding: '15px', background: '#fff', color: '#333' }}>
            <h3>{planName}</h3>
            <p><strong>Phong cách Body:</strong> {animeStyle}</p>
            <p><strong>Số ngày tập/tuần:</strong> {days}</p>
            <button style={{ background: '#e50914', color: '#fff', border: 'none', padding: '8px 15px', borderRadius: '4px', cursor: 'pointer' }}>
                Xem chi tiết
            </button>
        </div>
    );
};

export default WorkoutCard;