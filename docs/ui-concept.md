# Hệ Thống Thiết Kế (Design System & UI Concept) - AnimeFit Pro

Giao diện của AnimeFit Pro cần truyền tải được sự mạnh mẽ, năng lượng (Energy) và có chất công nghệ tương lai (Cyberpunk / Hi-Tech Anime), nhưng vẫn phải đảm bảo tính UX (Dễ sử dụng) của một ứng dụng SaaS/Fitness chuyên nghiệp. Không được làm quá màu mè gây rối mắt.

## 1. Định Hướng Phong Cách (Design Language)

- **Dark Theme First**: Mặc định là nền tối để phù hợp với môi trường phòng gym, tiết kiệm pin và làm nổi bật các điểm nhấn Neon.
- **Glassmorphism (Kính mờ)**: Sử dụng các card nền bán trong suốt với viền sáng mờ, tạo cảm giác công nghệ cao.
- **Micro-interactions (Hoạt ảnh nhỏ)**: Nút bấm có độ nảy khi click, các thanh Progress Bar chạy mượt mà, hiệu ứng lấp lánh (Sparkle) khi hoàn thành bài tập.
- **Gọn gàng & Hiện đại (Clean SaaS)**: Padding rộng rãi, phân cấp thông tin rõ ràng. Các thông số quan trọng (Set, Rep, Kg) phải to và dễ đọc.

## 2. Bảng Màu (Color Palette)

Hệ màu xoay quanh tông Tối và các điểm nhấn Neon đặc trưng của các phân cảnh "Gồng Aura" trong Anime.

- **Background (Nền chính)**:
  - Base: `#0B0C10` (Đen pha chút xanh navy cực trầm - Void Black).
  - Surface/Card: `#1F2833` (Xám xanh - Mảng sáng hơn một chút để phân tách Card).
- **Primary Accent (Màu chủ đạo)**:
  - Điện năng (Electric Violet): `#B5179E` hoặc Neon Blue: `#4CC9F0`.
  - Dùng cho nút bấm chính (CTA), thanh tiến trình (Progress Bar), Icon chính.
- **Secondary / Energy Accent (Màu năng lượng)**:
  - Saiyan Gold / Neon Orange: `#FCA311` hoặc Red Energy: `#F72585`.
  - Dùng cho các cảnh báo, streak đang cháy, hoặc biểu tượng thành tựu (Gamification).
- **Text & UI Elements**:
  - Tiêu đề chính (Heading): `#FFFFFF` (Trắng tinh).
  - Phụ đề (Body/Muted): `#94A3B8` (Slate xám nhạt).
  - Success (Hoàn thành Set): `#00F5D4` (Neon Green).

## 3. Nghệ Thuật Chữ (Typography)

Sử dụng Google Fonts để đảm bảo tính đồng bộ trên web.

- **Heading (Tiêu đề lớn, Hero, Tên màn hình)**:
  - Font: `Oswald` hoặc `Teko` hoặc `Rajdhani`.
  - Đặc điểm: Chữ cao, cứng cáp, mang đậm chất thể thao và công nghệ (Tech/Sci-Fi).
  - Trọng lượng (Weight): Bold (700) hoặc Black (900).
- **Body & Giao diện (Đoạn văn, Nhãn, Thông số, Form)**:
  - Font: `Inter` hoặc `Roboto`.
  - Đặc điểm: Cực kỳ rõ ràng, dễ đọc trên màn hình nhỏ, trung tính để làm nền cho các Heading nổi bật.

## 4. Các UI Components Đặc Trưng

- **Anime Body Goal Card**:
  - Card dọc, có hình ảnh vector hoặc minh hoạ của form dáng (Bulky, Shredded...).
  - Khi Hover, card có hiệu ứng glow xung quanh viền và hơi nhô lên (Scale 1.05).
- **Nút "Start Workout" (Khởi động buổi tập)**:
  - Nút to, dài toàn màn hình (Full-width) ở dưới cùng màn hình (Sticky Bottom).
  - Nền gradient, có hiệu ứng "breathing" (nhịp thở/chớp sáng chậm) để kêu gọi bấm vào.
- **Tick Box (Hoàn thành Set)**:
  - Thay vì checkbox vuông bình thường, sử dụng một nút bấm mượt, khi ấn vào sẽ trượt (Switch) màu xanh neon kèm theo Haptic Feedback (nếu làm app mobile).
- **Card Bài Tập (Exercise Card)**:
  - Bên trái là hình ảnh GIF thu nhỏ động tác.
  - Bên phải là Tên bài tập và Số Set/Rep.
  - Phân tầng rõ ràng.

## 5. Nguồn Cảm Hứng UI (Moodboard Inspiration)

- **Valorant / League of Legends UI Client**: Các đường nét sắc cạnh, viền highlight mỏng.
- **Cyberpunk 2077 HUD**: Màu chữ nổi bật trên nền đen, các thông số dạng thanh ngang.
- **Whoop / Oura Ring App**: Cách họ hiển thị biểu đồ sức khỏe tinh tế, dễ hiểu.
- **Strava**: Cách họ làm nhật ký tập luyện rất gọn.