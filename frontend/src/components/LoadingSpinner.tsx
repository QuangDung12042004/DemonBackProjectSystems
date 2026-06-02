import React from 'react';

interface LoadingProps {
    message?: string; // Dấu ? nghĩa là không bắt buộc phải có
}

const LoadingSpinner: React.FC<LoadingProps> = ({ message = "Đang rặn cơ... À nhầm, đang tải..." }) => {
    return (
        <div style={{ textAlign: 'center', padding: '20px' }}>
            <div style={{ fontSize: '30px', animation: 'spin 1s linear infinite' }}>⚙️</div>
            <p>{message}</p>
            <style>
                {`@keyframes spin { 100% { transform: rotate(360deg); } }`}
            </style>
        </div>
    );
};

export default LoadingSpinner;