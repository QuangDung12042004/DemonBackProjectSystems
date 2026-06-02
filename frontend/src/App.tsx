import React from 'react';
import Navbar from './layouts/Navbar';
import Sidebar from './layouts/Sidebar';
import WorkoutCard from './components/WorkoutCard';
import useLocalStorage from './hooks/useLocalStorage';

function App() {
  // 1. Dùng custom hook để lưu Theme (Mặc định là 'dark')
  const [theme, setTheme] = useLocalStorage<'light' | 'dark'>('app-theme', 'dark');

  // 2. Dùng custom hook để lưu Sở thích (Mặc định là phong cách Baki)
  const [targetStyle, setTargetStyle] = useLocalStorage<string>('user-target-style', 'Baki Hanma');

  // Đổi màu nền và chữ tùy theo Theme
  const isDark = theme === 'dark';
  const bgColor = isDark ? '#121212' : '#f4f4f4';
  const textColor = isDark ? '#ffffff' : '#333333';

  return (
    <div style={{ display: 'flex', flexDirection: 'column', height: '100vh', margin: 0, fontFamily: 'sans-serif' }}>
      <Navbar />

      <div style={{ display: 'flex', flex: 1 }}>
        <Sidebar />

        <main style={{ flex: 1, padding: '20px', background: bgColor, color: textColor, transition: 'all 0.3s ease' }}>

          <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
            <h2>Hệ thống huấn luyện Anime Body!</h2>

            {/* Nút bấm chuyển đổi Theme */}
            <button
              onClick={() => setTheme(isDark ? 'light' : 'dark')}
              style={{ padding: '8px 16px', cursor: 'pointer', borderRadius: '5px', background: isDark ? '#ffffff' : '#121212', color: isDark ? '#000000' : '#ffffff' }}
            >
              Chuyển sang {isDark ? 'Chế độ Sáng ☀️' : 'Chế độ Tối 🌙'}
            </button>
          </div>

          <div style={{ marginTop: '20px' }}>
            <p>Mục tiêu hiện tại của bạn: <strong>{targetStyle}</strong></p>
            <button onClick={() => setTargetStyle('Toji Fushiguro')} style={{ marginRight: '10px' }}>Đổi mục tiêu thành Toji</button>
            <button onClick={() => setTargetStyle('Goku')}>Đổi mục tiêu thành Goku</button>
          </div>

          <div style={{ display: 'flex', gap: '20px', marginTop: '30px' }}>
            <WorkoutCard planName="Giáo án Sức mạnh" animeStyle={targetStyle} days={5} />
          </div>

        </main>
      </div>
    </div>
  );
}

export default App;